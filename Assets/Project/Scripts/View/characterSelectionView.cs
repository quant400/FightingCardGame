using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;
using UniRx.Triggers;
using UniRx.Operators;
using System.Linq;
public class characterSelectionView : MonoBehaviour
{
    [Serializable]
    public class characterButton
    {
        public Button charctersChoicesBtn;
        public fighterClass characterButtonClass;
    }
    public class itemsButtons
    {
        public Button itemsChoicesBtn;
        public wearablesClass itemsButtonClass;
    }
    public GameObject fighterHolderParent;
    public GameObject itemsHolderParent;

    public List<characterButton> charctersChoicesList = new List<characterButton>();
    public List<itemsButtons> itemsChoicesList = new List<itemsButtons>();

    public fighterModel.fighterData localChoosenFighterData;
    public List<fighterModel.wearables> localChoosenFighterItemsData = new List<fighterModel.wearables>();
    public int numberOfChosingCharacterLimits;
    [SerializeField] int characterRarity;
    // Start is called before the first frame update
    void Start()
    {
        if (fighterHolderParent.GetComponentsInChildren<Button>() != null)
        {
            Button[] buttons = fighterHolderParent.GetComponentsInChildren<Button>();
            for (int i = 0; i < buttons.Length; i++)
            {
                characterButton character = new characterButton();
                character.charctersChoicesBtn = buttons[i];
                if (buttons[i].GetComponent<fighterClass>() != null)
                {
                    character.characterButtonClass = buttons[i].GetComponent<fighterClass>();

                }
                charctersChoicesList.Add(character);
            }
        }
        if (itemsHolderParent.GetComponentsInChildren<Button>() != null)
        {
            Button[] buttons = itemsHolderParent.GetComponentsInChildren<Button>();
            for (int i = 0; i < buttons.Length; i++)
            {
                itemsButtons items = new itemsButtons();
                items.itemsChoicesBtn = buttons[i];
                if (buttons[i].GetComponent<wearablesClass>() != null)
                {
                    items.itemsButtonClass = buttons[i].GetComponent<wearablesClass>();

                }
                itemsChoicesList.Add(items);
            }
        }
        observeChoosenCharacter();
    }
  

    // Update is called once per frame
    void Update()
    {
        
    }
    void observeChoosenCharacter()
    {
        for (int i = 0; i < charctersChoicesList.Count; i++)
        {
            int buttonIdex = i;
            charctersChoicesList[i].charctersChoicesBtn.OnClickAsObservable()
                .Select(_ => charctersChoicesList[buttonIdex].characterButtonClass)
                .Do(_ => addFighter(_))
                .Subscribe()
                .AddTo(this);
        }
        for (int i = 0; i < itemsChoicesList.Count; i++)
        {
            int buttonIdex = i;
            itemsChoicesList[i].itemsChoicesBtn.OnClickAsObservable()
                .Select(_ => itemsChoicesList[buttonIdex].itemsButtonClass)
                .Do(_ => addItemWearables(_))
                .Subscribe()
                .AddTo(this);
        }
    }
    public void addFighter(fighterClass fighter)
    {
        fighter.setFighterChoosenToDataBase();
        localChoosenFighterData = fighter.fighterDataObj;
    }
    public void addItemWearables(wearablesClass item)
    {
        item.setFighterItemToDataBase();
        localChoosenFighterItemsData = fighterModel.currentChosenFighter.currentWearablesSelected;
    }
}
