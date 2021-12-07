using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;
using UniRx.Triggers;
using UniRx.Operators;
using System.Linq;
public class deckView : MonoBehaviour
{
    [Serializable]
    public class cardButton
    {
        public Button cardChoiceButton;
        public cardClass cardButtonClass;
    }

    public GameObject cardHolderParent;
    public List<cardButton> cardsChoices=new List<cardButton>();
    public int deckFormingLimit;
    public List<deckModel.cardID> localFormedDeck = new List<deckModel.cardID>();
    public ReactiveProperty<int> leftSpots = new ReactiveProperty<int>();
    // Start is called before the first frame update
    void Start()
    {
        leftSpots.Value = 20;
        if (cardHolderParent.GetComponentsInChildren<Button>() != null)
        {
            Button[] buttons = cardHolderParent.GetComponentsInChildren<Button>();
            for(int i =0; i < buttons.Length; i++)
            {
                cardButton card = new cardButton();
                card.cardChoiceButton = buttons[i];
                if (buttons[i].GetComponent<cardClass>() != null)
                {
                    card.cardButtonClass = buttons[i].GetComponent<cardClass>();

                }
                cardsChoices.Add(card);
            }
        }
        observeCardsChoiceButtons();
    }
    void observeCardsChoiceButtons()
    {
        for (int i = 0; i < cardsChoices.Count; i++)
        {
            int buttonIdex = i;
            cardsChoices[i].cardChoiceButton.OnClickAsObservable()
                .Select(_ => cardsChoices[buttonIdex].cardButtonClass)
                .Do(_ => addCard(_))
                .Subscribe()
                .AddTo(this);
        }
        leftSpots
            .Where(_ => leftSpots.Value == 0)
            .Do(_ => Debug.Log("deck formed"))
            .Subscribe()
            .AddTo(this);
    }
    public void addCard(cardClass cardClassObj)
    {
        if (!cardClassObj.cardChoosen)
        {
            if (leftSpots.Value > 0)
            {
                localFormedDeck.Add(cardClassObj.cardData);
                cardClassObj.cardChoosen = true;
                leftSpots.Value--;
            }
            
            
        }
        else
        {


            deckModel.cardID searchedFile = localFormedDeck.Find(x => x.id == cardClassObj.cardData.id);
            if (searchedFile != null)
            {
                localFormedDeck.Remove(searchedFile);
                localFormedDeck = localFormedDeck.Where(x => x != null).ToList();
                leftSpots.Value++;
                cardClassObj.cardChoosen = false;

            }


        }
        deckModel.currentDeck = localFormedDeck;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
