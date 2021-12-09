
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
    public deckModel.cardID cardData;
    public bool cardChoosen;
    public void Start()
    {
        cardData = new deckModel.cardID();
        cardData.id = UnityEngine.Random.Range(0, 999);
        cardData.type= (deckModel.cardType)UnityEngine.Random.Range(0, 3);
        gameObject.GetComponentInChildren<Text>().text = cardData.type.ToString()+ " Card N : " + cardData.id;

    }
}
