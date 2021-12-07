
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;
using UniRx.Triggers;
using UniRx.Toolkit;
[Serializable]

public struct deckModel
{
    [Serializable]

    public class cardID
    {
        public int id;
        public GameObject prefab;
        public int staminaRequired;

    }
    public static int deckMaxCount=20;
    public static int cardsCounts=50;
    public static int deckID;
    public static List<cardID> currentDeck= new List<cardID>(20);
    public static List<cardID> lastDeck = new List<cardID>(20);
    public static int leftCardsInGame=20;
    public static bool deckFormed;
    public static bool noLeftCards;
    
}
