using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Carty.CartyLib;
using Carty.CartyLib.Internals.CardsComponents;
using Carty.CartyLib.Internals.BoardComponents;
using Carty.CartyVisuals;

public class VisualTests : MonoBehaviour
{
    public Text Text;
    public bool CreateCardTest = true;
    public bool CardOverCardTest = true;
    public bool PlayerHandFullTest = true;
    public bool EnemyHandFullTest = true;
    public bool PlayerHandFillingTest = true;
    public bool EnemyHandFillingTest = true;
    public bool PlayerDeck30Test = true;
    public bool EnemyDeck30Test = true;
    public bool PlayerDrawsCardTest = true;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(StartTests());
    }

    private IEnumerator StartTests()
    {
        if (CreateCardTest) yield return StartCoroutine(CreateCard());
        if (CardOverCardTest) yield return StartCoroutine(CardOverCard());
        if (PlayerHandFullTest) yield return StartCoroutine(PlayerHandFull());
        if (EnemyHandFullTest) yield return StartCoroutine(EnemyHandFull());
        if (PlayerHandFillingTest) yield return StartCoroutine(PlayerHandFilling());
        if (EnemyHandFillingTest) yield return StartCoroutine(EnemyHandFilling());
        if (PlayerDeck30Test) yield return StartCoroutine(PlayerDeck30());
        if (EnemyDeck30Test) yield return StartCoroutine(EnemyDeck30());
        if (PlayerDrawsCardTest) yield return StartCoroutine(PlayerDrawsCard());
    }

    private IEnumerator CreateCard()
    {
        GameObject card = GameManager.Instance.CardManager.CreateCard("", true);

        Text.text = "There is card in the middle of the screen.";

        yield return new WaitForSeconds(5.0f);

        Destroy(card);
    }

    private IEnumerator CardOverCard()
    {
        GameObject card_right = GameManager.Instance.CardManager.CreateCard("", true);
        card_right.transform.position = new Vector3(0.4f, 0.5f, 0);
        GameObject card_left = GameManager.Instance.CardManager.CreateCard("", true);
        card_left.transform.position = new Vector3(-0.4f, 0.0f, 0);
        Text.text = "The right card is drawn over the left card";

        yield return new WaitForSeconds(5.0f);

        Destroy(card_right);
        Destroy(card_left);
    }

    private IEnumerator PlayerHandFull()
    {
        int max = GameManager.Instance.Settings.MaxCardsInHand;
        GameObject[] cards = new GameObject[max];
        for (int i = 0; i < max; i++)
        {
            cards[i] = GameManager.Instance.CardManager.CreateCard("", true);
            cards[i].transform.position = VisualManager.Instance.HandPositioning.PositionPlayer(i, max);
            cards[i].transform.rotation = VisualManager.Instance.HandPositioning.RotationPlayer(i, max);
        }

        Text.text = "Player hand with " + max + " cards.";

        yield return new WaitForSeconds(5.0f);

        for (int i = 0; i < max; i++)
        {
            Destroy(cards[i]);
        }
    }

    private IEnumerator EnemyHandFull()
    {
        int max = GameManager.Instance.Settings.MaxCardsInHand;
        GameObject[] cards = new GameObject[max];
        for (int i = 0; i < max; i++)
        {
            cards[i] = GameManager.Instance.CardManager.CreateCard("", false);
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
        Hand hand = Hand.CreateHand(true);


        int max = GameManager.Instance.Settings.MaxCardsInHand;
        GameObject[] cards = new GameObject[max];

        Text.text = "Player hand is being filled with " + max + " cards.";

        for (int i = 0; i < max; i++)
        {
            hand.PrepareAddingCard();
            cards[i] = GameManager.Instance.CardManager.CreateCard("", true);
            hand.Add(cards[i].GetComponent<CanBeInHand>());
            yield return new WaitForSeconds(2.0f);
        }

        yield return new WaitForSeconds(2.0f);

        for (int i = 0; i < max; i++)
        {
            Destroy(cards[i]);
        }
    }

    private IEnumerator EnemyHandFilling()
    {
        Hand hand = Hand.CreateHand(false);

        int max = GameManager.Instance.Settings.MaxCardsInHand;
        GameObject[] cards = new GameObject[max];

        Text.text = "Enemy hand is being filled with " + max + " cards.";

        for (int i = 0; i < max; i++)
        {
            hand.PrepareAddingCard();
            cards[i] = GameManager.Instance.CardManager.CreateCard("", false);
            cards[i].transform.rotation = VisualManager.Instance.FlippedOff;
            hand.Add(cards[i].GetComponent<CanBeInHand>());
            yield return new WaitForSeconds(2.0f);
        }

        yield return new WaitForSeconds(2.0f);

        for (int i = 0; i < max; i++)
        {
            Destroy(cards[i]);
        }
    }

    private IEnumerator PlayerDeck30()
    {
        int amount = 30;
        Text.text = "Player deck with " + amount + " cards.";

        GameObject[] cards = new GameObject[amount];

        for (int i = 0; i < amount; i++)
        {
            cards[i] = GameManager.Instance.CardManager.CreateCard("", true);
            cards[i].transform.position = VisualManager.Instance.DeckPositioning.PositionPlayer(i, amount);
            cards[i].transform.rotation = VisualManager.Instance.DeckPositioning.RotationPlayer(i, amount);
        }

        yield return new WaitForSeconds(5.0f);

        for (int i = 0; i < amount; i++)
        {
            Destroy(cards[i]);
        }
    }

    private IEnumerator EnemyDeck30()
    {
        int amount = 30;
        Text.text = "Enemy deck with " + amount + " cards.";

        GameObject[] cards = new GameObject[amount];

        for (int i = 0; i < amount; i++)
        {
            cards[i] = GameManager.Instance.CardManager.CreateCard("", false);
            cards[i].transform.position = VisualManager.Instance.DeckPositioning.PositionEnemy(i, amount);
            cards[i].transform.rotation = VisualManager.Instance.DeckPositioning.RotationEnemy(i, amount);
        }

        yield return new WaitForSeconds(5.0f);

        for (int i = 0; i < amount; i++)
        {
            Destroy(cards[i]);
        }
    }

    private IEnumerator PlayerDrawsCard()
    {
        Text.text = "Player draws a card from deck.";

        GameObject card = GameManager.Instance.CardManager.CreateCard("", false);
        card.transform.position = VisualManager.Instance.DeckPositioning.PositionPlayer(0, 1);
        card.transform.rotation = VisualManager.Instance.DeckPositioning.RotationPlayer(0, 1);

        VisualManager.Instance.HighLevelCardMovement.MoveCardFromDeckToDrawDisplayArea(card.GetComponent<CanBeMoved>());

        yield return new WaitForSeconds(5.0f);

        Destroy(card);
    }

}

