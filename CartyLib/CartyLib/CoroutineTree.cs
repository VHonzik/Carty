using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CartyLib
{
    abstract public class CoroutineInstance
    {
        public abstract IEnumerator Execute();
    }

    public class CoroutineNode
    {
        private readonly List<CoroutineNode> _children = new List<CoroutineNode>();        
        private readonly CoroutineInstance _value;

        public CoroutineNode(CoroutineInstance value)
        {
            _value = value;
        }

        public CoroutineNode this[int i]
        {
            get { return _children[i]; }
        }

        public CoroutineNode Parent { get; private set; }
        public CoroutineInstance Value { get { return _value; } }

        public ReadOnlyCollection<CoroutineNode> Children
        {
            get { return _children.AsReadOnly(); }
        }

        public CoroutineNode AddChild(CoroutineInstance coroutine)
        {
            var node = new CoroutineNode(coroutine) { Parent = this };
            _children.Add(node);
            return node;
        }

        public void ClearChildren()
        {
            _children.Clear();
        }
    }

    public class CoroutineTree
    {
        public CoroutineNode Root { get; private set; }
        public CoroutineNode CurrentNode { get; private set; }

        public CoroutineTree()
        {
            Root = new CoroutineNode(null);
            CurrentNode = Root;
        }

        public void Start()
        {
            UnityBridge.Instance.StartCoroutine(UpdateTree());
        }

        public void AddCurrent(CoroutineInstance value)
        {
            CurrentNode.AddChild(value);
        }

        public void AddRoot(CoroutineInstance value)
        {
            Root.AddChild(value);
        }

        private IEnumerator ProcessChildrenOfNode(CoroutineNode node)
        {
            int i = 0;
            while(i < node.Children.Count)
            {
                CurrentNode = node[i];
                yield return UnityBridge.Instance.StartCoroutine(node[i].Value.Execute());

                if(node[i].Children.Count > 0)
                {
                    yield return UnityBridge.Instance.StartCoroutine(ProcessChildrenOfNode(node[i]));
                }                

                i++;
            }

            if (node == Root)
            {
                CurrentNode = Root;
                Root.ClearChildren();
            }
        }

        private IEnumerator UpdateTree()
        {
            while (true)
            {
                if(CurrentNode == Root && Root.Children.Count > 0)
                {
                    yield return UnityBridge.Instance.StartCoroutine(ProcessChildrenOfNode(Root));
                }
                else
                {
                    yield return null;
                }
            }
        }
    }
}
