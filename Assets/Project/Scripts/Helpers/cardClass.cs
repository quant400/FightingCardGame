
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UniRx;
using UniRx.Triggers;
using UniRx.Toolkit;
[Serializable]

public class cardClass : MonoBehaviour
{
    public deckModel.cardID cardData=new deckModel.cardID();
    public bool cardChoosen;
    public void Start()
    {
        cardData.type= (deckModel.cardType)UnityEngine.Random.Range(0, 4);
        cardData.cardRarityValue = UnityEngine.Random.Range(0, 2);

    }
    public void setCardData(deckModel.cardID cardDataSaved)
    {
        cardData = cardDataSaved;
        gameObject.GetComponent<Button>().image.sprite = deckModel.cardsTextureSprites[cardData.id]; //This is what I need help with

    }
}
