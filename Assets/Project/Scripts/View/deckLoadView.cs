using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;
using UniRx.Triggers;
using UniRx.Operators;
using System.Linq;
using System.IO;


public class deckLoadView : MonoBehaviour
{
    public GameObject loadedCardsParent;
    public GameObject cardPrefab;
    public List<deckView.cardButton> currentHoldenCards = new List<deckView.cardButton>();
    public int cardStartLimit=5;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void loadCardsAtStart(inGameDeckModels.playerDecksModels playerDeck)
    {
        if (playerDeck.InGamePlayersDeckModel != null)
        {
            if (playerDeck.InGamePlayersDeckModel.currentDeckLeftCards.Count >= cardStartLimit)
            {
                playerDeck.InGamePlayersDeckModel.currentDeckLeftCards = deckView.Shuffle(deckModel.currentDeckLeftCards);
                for (int i = 0; i < cardStartLimit; i++)
                {
                    GameObject clone = Instantiate(cardPrefab, loadedCardsParent.transform);
                    deckView.cardButton card = new deckView.cardButton();
                    card.cardChoiceButton = clone.GetComponent<Button>();
                    card.cardButtonClass = clone.GetComponent<cardClass>();
                    card.cardButtonClass.setCardData(playerDeck.InGamePlayersDeckModel.currentDeckLeftCards[i]);

                    playerDeck.InGamePlayersDeckModel.currentDeckLeftCards.Remove(deckModel.currentDeckLeftCards[i]);
                    playerDeck.InGamePlayersDeckModel.currentDeckLeftCards = playerDeck.InGamePlayersDeckModel.currentDeckLeftCards.Where(x => x != null).ToList();
                    currentHoldenCards.Add(card);

                }
            }
        }
    }
    public void loadTurnCard(int numberOfCards, inGameDeckModels.playerDecksModels playerDeck)
    {
        if (playerDeck.InGamePlayersDeckModel != null)
        {
            if (playerDeck.InGamePlayersDeckModel.currentDeckLeftCards.Count >= numberOfCards)
            {
                playerDeck.InGamePlayersDeckModel.currentDeckLeftCards = deckView.Shuffle(deckModel.currentDeckLeftCards);
                for (int i = 0; i < numberOfCards; i++)
                {
                    GameObject clone = Instantiate(cardPrefab, loadedCardsParent.transform);
                    deckView.cardButton card = new deckView.cardButton();
                    card.cardChoiceButton = clone.GetComponent<Button>();
                    card.cardButtonClass = clone.GetComponent<cardClass>();
                    card.cardButtonClass.setCardData(playerDeck.InGamePlayersDeckModel.currentDeckLeftCards[i]);

                    playerDeck.InGamePlayersDeckModel.currentDeckLeftCards.Remove(deckModel.currentDeckLeftCards[i]);
                    playerDeck.InGamePlayersDeckModel.currentDeckLeftCards = playerDeck.InGamePlayersDeckModel.currentDeckLeftCards.Where(x => x != null).ToList();
                    currentHoldenCards.Add(card);

                }
            }

        }
    }
    
}
