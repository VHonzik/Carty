using UnityEngine;
using System.Collections;
using CartyLib;
using UnityEngine.UI;
using CartyLib.CardsComponenets;
using CartyLib.BoardComponents;
using CartyVisuals;

public class VisualTests : MonoBehaviour {

    public Text Text;
    public bool CreateCardTest = true;
    public bool CardOverCardTest = true;
    public bool PlayerHandFullTest = true;
    public bool EnemyHandFullTest = true;
    public bool PlayerHandFillingTest = true;
    

    // Use this for initialization
    void Start () {
        StartCoroutine(StartTests());
	}

    private IEnumerator StartTests()
    {
        if (CreateCardTest) yield return StartCoroutine(CreateCard());
        if (CardOverCardTest) yield return StartCoroutine(CardOverCard());
        if (PlayerHandFullTest) yield return StartCoroutine(PlayerHandFull());
        if (EnemyHandFullTest) yield return StartCoroutine(EnemyHandFull());
        if (PlayerHandFillingTest) yield return StartCoroutine(PlayerHandFilling());
        
    }

    private IEnumerator CreateCard()
    {
        GameObject card = CartyEntitiesConstructors.CreateCard();

        Text.text = "There is card in the middle of the screen.";

        yield return new WaitForSeconds(5.0f);

        Destroy(card);
    }

    private IEnumerator CardOverCard()
    {
        GameObject card_right = CartyEntitiesConstructors.CreateCard();
        card_right.transform.position = new Vector3(0.4f, 0.5f, 0);
        GameObject card_left = CartyEntitiesConstructors.CreateCard();
        card_left.transform.position = new Vector3(-0.4f, 0.0f, 0);
        Text.text = "The right card is drawn over the left card";

        yield return new WaitForSeconds(5.0f);

        Destroy(card_right);
        Destroy(card_left);
    }

    private IEnumerator PlayerHandFull()
    {
        int max = CartyVisuals.VisualManager.Instance.MaxCardsInHand;
        GameObject[] cards = new GameObject[max];
        for(int i=0; i < max; i++)
        {
            cards[i] = CartyEntitiesConstructors.CreateCard();
            cards[i].transform.position = VisualManager.Instance.HandPositioning.PositionPlayer(i, max);
            cards[i].transform.rotation = VisualManager.Instance.HandPositioning.RotationPlayer(i, max);
        }

        Text.text = "Player hand with "+ max + " cards.";

        yield return new WaitForSeconds(5.0f);

        for (int i = 0; i < max; i++)
        {
            Destroy(cards[i]);
        }
    }

    private IEnumerator EnemyHandFull()
    {
        int max = CartyVisuals.VisualManager.Instance.MaxCardsInHand;
        GameObject[] cards = new GameObject[max];
        for (int i = 0; i < max; i++)
        {
            cards[i] = CartyEntitiesConstructors.CreateCard();
            cards[i].transform.position = VisualManager.Instance.HandPositioning.PositionEnemy(i, max);
            cards[i].transform.rotation = VisualManager.Instance.HandPositioning.RotationEnemy(i, max);
        }

        Text.text = "Enemy hand with " + max + " cards.";

        yield return new WaitForSeconds(5.0f);

        for (int i = 0; i < max; i++)
        {
            Destroy(cards[i]);
        }
    }

    private IEnumerator PlayerHandFilling()
    {
        Hand hand = CartyEntitiesConstructors.CreateHand(true);
        
        int max = CartyVisuals.VisualManager.Instance.MaxCardsInHand;
        GameObject[] cards = new GameObject[max];
        for (int i = 0; i < max; i++)
        {
            hand.PrepareAddingCard();
            cards[i] = CartyEntitiesConstructors.CreateCard();
            cards[i].GetComponent<CanBeOwned>().PlayerOwned = true;
            hand.Add(cards[i].GetComponent<CanBeInHand>());
            yield return new WaitForSeconds(2.0f);
        }

        Text.text = "Player hand is being filled with " + max + " cards.";

        yield return new WaitForSeconds(2.0f);

        for (int i = 0; i < max; i++)
        {
            Destroy(cards[i]);
        }
    }

}
