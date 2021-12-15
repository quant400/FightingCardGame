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
    [SerializeField] int deckRarity;
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
        loadResourcesSprites();
        setCardsTexturesAndId();
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
            .Do(_ => deckModel.currentDeckLeftCards = deckModel.currentDeck)
            .Subscribe()
            .AddTo(this);
    }
    public void addCard(cardClass cardClassObj)
    {
        bool cardTypeCheck = false;
        if (!cardClassObj.cardChoosen)
        {
            if (leftSpots.Value > 0)
            {
                cardTypeCheck = checkCardBeforeAdd(cardClassObj.cardData.type, true);
                if (cardTypeCheck)
                {
                    localFormedDeck.Add(cardClassObj.cardData);
                    cardClassObj.cardChoosen = true;
                    cardClassObj.gameObject.GetComponent<Button>().image.color = Color.green;
                    leftSpots.Value--;
                    if (cardClassObj.cardData.cardRarityValue != 0)
                    {
                        deckModel.deckRarityValue += cardClassObj.cardData.cardRarityValue;
           
                    }
                }
                else
                {
                    Debug.Log("you reach " + cardClassObj.cardData.type .ToString()+ "card Limit");
                }
                
               

            }
            
            
        }
        else
        {


            deckModel.cardID searchedFile = localFormedDeck.Find(x => x.id == cardClassObj.cardData.id);
            if (searchedFile != null)
            {
                cardTypeCheck = checkCardBeforeAdd(cardClassObj.cardData.type, false);
                localFormedDeck.Remove(searchedFile);
                localFormedDeck = localFormedDeck.Where(x => x != null).ToList();
                leftSpots.Value++;
                cardClassObj.cardChoosen = false;
                cardClassObj.gameObject.GetComponent<Button>().image.color = Color.white;
                if (cardClassObj.cardData.cardRarityValue != 0)
                {
                    deckModel.deckRarityValue -= cardClassObj.cardData.cardRarityValue;
                }

            }


        }
        deckModel.currentDeck = localFormedDeck;
        deckRarity = deckModel.deckRarityValue;
    }
    public bool checkCardBeforeAdd(deckModel.cardType type, bool add)
    {
        bool cond=false;
        if (add)
        {
            switch (type)
            {
                case deckModel.cardType.Diamond:
                    if (deckModel.CurrentDiamondCards < deckModel.DiamondLimit)
                    {
                        cond = true;
                        deckModel.CurrentDiamondCards += 1;
                    }
                       
                        break;
                case deckModel.cardType.Gold:
                    if (deckModel.CurrentGoldCards < deckModel.GoldLimit)
                    {
                        deckModel.CurrentGoldCards += 1;
                        cond = true;
                    }
                        
                    break;
                case deckModel.cardType.Silver:
                    if (deckModel.CurrentSilverCards < deckModel.SilverLimit)
                    {
                        deckModel.CurrentSilverCards += 1;
                        cond = true;
                    }
                     
                    break;
            }
            return cond;
            
        }
        else
        {
            switch (type)
            {
                case deckModel.cardType.Diamond:
                    if (deckModel.CurrentDiamondCards >= 1)
                    {
                        cond = true;
                        deckModel.CurrentDiamondCards -= 1;
                    }

                    break;
                case deckModel.cardType.Gold:
                    if (deckModel.CurrentGoldCards >= 1)
                    {
                        deckModel.CurrentGoldCards -= 1;
                        cond = true;
                    }

                    break;
                case deckModel.cardType.Silver:
                    if (deckModel.CurrentSilverCards >= 1)
                    {
                        deckModel.CurrentSilverCards -= 1;
                        cond = true;
                    }

                    break;
            }
            return cond;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public static List<T> Shuffle<T>(List<T> _list)
    {
        for (int i = 0; i < _list.Count; i++)
        {
            T temp = _list[i];
            int randomIndex = UnityEngine.Random.Range(i, _list.Count);
            _list[i] = _list[randomIndex];
            _list[randomIndex] = temp;
        }

        return _list;
    }
    public void setCardsTexturesAndId()
    {
        setCardsID();
        for (int i = 0; i < cardsChoices.Count; i++)
        {
           

            cardsChoices[i].cardChoiceButton.image.sprite = deckModel.cardsTextureSprites[i]; //This is what I need help with

            
        }
    }
    void setCardsID()
    {
        for (int i = 0; i < cardsChoices.Count; i++)
        {
            setCardsID(cardsChoices[i].cardButtonClass, i);

        }
    }
    void imagePathesSet()
    {
        string[] pathes;
        deckModel.cardsFolderPath = Application.streamingAssetsPath + "/Cards/";  //Get path of folder
        pathes = Directory.GetFiles(deckModel.cardsFolderPath, "*.jpg"); // Get all files of type .png in this folder
        if (pathes != null)
        {

            for (int i = 0; i < pathes.Length; i++)
            {
                deckModel.cardsTexturesPaths.Add(pathes[i]); // set pathes in the model
                Debug.Log(pathes[i]);
            }
        }
        
    }
    void loadResourcesSprites()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("Cards") as Sprite[];
        if (sprites != null)
        {
            for (int i = 0; i < sprites.Length; i++)
            {
                deckModel.cardsTextureSprites.Add(sprites[i]); // set pathes in the model
            }
        }
    }
    void setCardsID(cardClass card,int id)
    {
        card.cardData.id = id;
        card.gameObject.GetComponentInChildren<Text>().text = card.cardData.type.ToString() + " Card N : " + card.cardData.id;

    }
}
