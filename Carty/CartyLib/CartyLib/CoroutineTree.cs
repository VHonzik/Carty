using System.Collections;
using System.Collections.Generic;

namespace Carty.CartyLib.Internals
{
    /// <summary>
    /// A data structure representing one coroutine as node of a tree.
    /// </summary>
    public class CoroutineNode
    {
        /// <summary>
        /// List of children nodes.
        /// </summary>
        private readonly List<CoroutineNode> _children = new List<CoroutineNode>();    
            
        public CoroutineNode(IEnumerator value)
        {
            Value = value;
        }

        /// <summary>
        /// Accessor for a children node.
        /// Does not check for index validity.
        /// </summary>
        /// <param name="i">Index of wanted child.</param>
        /// <returns></returns>
        public CoroutineNode this[int i]
        {
            get { return _children[i]; }
        }

        /// <summary>
        /// Parent node.
        /// Is null for root of a tree.
        /// </summary>
        public CoroutineNode Parent { get; private set; }

        /// <summary>
        /// Actual coroutine.
        /// </summary>
        public IEnumerator Value { get; private set; }

        /// <summary>
        /// Number of children this node has.
        /// </summary>
        public int ChildrenCount
        {
            get { return _children.Count; }
        }

        /// <summary>
        /// Add a coroutine as a child of the node.
        /// </summary>
        /// <param name="coroutine">Coroutine to add.</param>
        /// <returns></returns>
        public CoroutineNode AddChild(IEnumerator coroutine)
        {
            var node = new CoroutineNode(coroutine) { Parent = this };
            _children.Add(node);
            return node;
        }

        /// <summary>
        /// Remove all children of this node.
        /// </summary>
        public void ClearChildren()
        {
            _children.Clear();
        }
    }

    /// <summary>
    /// A tree of coroutines with depth-first order of execution.
    /// I.e. node -> children -> siblings.
    /// </summary>
    public class CoroutineTree
    {
        /// <summary>
        /// Artificial root node.
        /// Does not contain an actual coroutine.
        /// </summary>
        public CoroutineNode Root { get; private set; }

        /// <summary>
        /// Node which is currently being executed.
        /// Points to Root when the tree is empty.
        /// </summary>
        public CoroutineNode CurrentNode { get; private set; }

        public CoroutineTree()
        {
            Root = new CoroutineNode(null);
            CurrentNode = Root;
        }

        /// <summary>
        /// Start processing of the tree.
        /// </summary>
        public void Start()
        {
            UnityBridge.Instance.StartCoroutine(UpdateTree());
        }

        /// <summary>
        /// Add a coroutine as child of the current node.
        /// </summary>
        /// <param name="value">Coroutine to add.</param>
        public void AddCurrent(IEnumerator value)
        {
            CurrentNode.AddChild(value);
        }

        /// <summary>
        /// Add a coroutine as a child of the root node.
        /// </summary>
        /// <param name="value">Coroutine to add.</param>
        public void AddRoot(IEnumerator value)
        {
            Root.AddChild(value);
        }

        /// <summary>
        /// Add a coroutine as a child of the current node which waits for specified amount of time.
        /// </summary>
        /// <param name="seconds"></param>
        public void AddCurrentWait(float seconds)
        {
            CurrentNode.AddChild(UnityBridge.Instance.Wait(seconds));
        }

        /// <summary>
        /// Add a coroutine as a child of the root node which waits for specified amount of time.
        /// </summary>
        /// <param name="seconds"></param>
        public void AddRootWait(float seconds)
        {
            Root.AddChild(UnityBridge.Instance.Wait(seconds));
        }

        /// <summary>
        /// Returns true if the tree is empty, false otherwise.
        /// </summary>
        public bool Empty
        {
            get { return Root == CurrentNode && Root.ChildrenCount <= 0; }
        }

        private IEnumerator ProcessChildrenOfNode(CoroutineNode node)
        {
            int i = 0;
            while(i < node.ChildrenCount)
            {
                // Node -> children -> siblings.
                CurrentNode = node[i];
                yield return UnityBridge.Instance.StartCoroutine(node[i].Value);

                if (i >= node.ChildrenCount) yield break;

                if(node[i].ChildrenCount > 0)
                {
                    // Recursion on children.
                    yield return UnityBridge.Instance.StartCoroutine(ProcessChildrenOfNode(node[i]));
                }                

                i++;
            }

            // Be defensive about clearing, do it only when everything was executed.
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
                if(CurrentNode == Root && Root.ChildrenCount > 0)
                {
                    yield return UnityBridge.Instance.StartCoroutine(ProcessChildrenOfNode(Root));
                }
                else
                {
                    yield return null;
                }
            }
        }

        /// <summary>
        /// Removes all pending coroutines.
        /// </summary>
        public void CleanUp()
        {
            CurrentNode = Root;
            Root.ClearChildren();
        }
    }
}
