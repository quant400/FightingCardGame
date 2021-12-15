
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
    public enum cardType
        {
        Diamond,Gold,Silver
        };
    [Serializable]
    public class cardID
    {
        public int id;
        public GameObject prefab;
        public int staminaRequired;
        public int cardRarityValue;
        public cardType type;
        public string cardDiscription;
    }
    public static int deckMaxCount=20;
    public static int cardsCounts=50;
    public static int deckID;
    public static List<cardID> currentDeck= new List<cardID>(20);
    public static List<cardID> currentDeckLeftCards = new List<cardID>(20);
    public static List<cardID> lastDeck = new List<cardID>(20);
    public static int leftCardsInGame=20;
    public static bool deckFormed;
    public static bool noLeftCards;
    public static int deckRarityValue;
    public static int DiamondLimit=4;
    public static int GoldLimit = 6;
    public static int SilverLimit = 10;
    public static int CurrentDiamondCards = 0;
    public static int CurrentGoldCards = 0;
    public static int CurrentSilverCards = 0;
    public static List<string> cardsTexturesPaths = new List<string>();
    public static List<Sprite> cardsTextureSprites = new List<Sprite>();
    public static  string cardsFolderPath;
    

}
