
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
        Diamond,Gold,Bronze,Silver
        };
    [Serializable]

    public enum Tier
    {
        attack,defense,buff
    };
    public enum buffDuration
    {
        thisTurn,
        nextTurn,
        twoTurns,
        fullGame,
    }
    public enum buffEffectdPlayer
    {
        self,
        otherPlayer,
        allPlayers,
    }
    public enum buffEffectedValueType
    {
        none,
        damage,
        technique,
        shield,
        cretical,
        energy,
        strike,
        heal,
        hit,
        invalidCard,
        defence,
        drawCard,
        allDrawCard,
        removeCardFromHand,
        healFromCardDamage,
        Debuff,
    }
    public enum valueAddedType
    {
        up,
        down,
        revert,
        steal,
        ignore,
        normal,
        chanceSelf,
        chanceOpp,
        block,
        chanceRiskHit,
        multi,
        multiOnShield,
        miss,

    }
    [Serializable]

    public class buffEffectCondition
    {
        public buffEffectedValueType type;
        public valueAddedType valueAddedDetails;
    }
    [Serializable]
    public class cardID
    {
        public int id;
        public GameObject prefab;
        public int staminaRequired;
        public int cardRarityValue;
        public int attackValue;
        public int defenceValue;
        public string stringName;
        public int combIDCode;
        public cardType type;
        public Tier cardTier;
        public cardBuffEffect buffEffectData;
        public string cardDiscription;
    }
    [Serializable]

    public class combineCardCondition
    {
        public bool needCombine;
        public int combineCardId;
        public bool otherCardOwned;
    }
    [Serializable]

    public class cardBuffEffect
    {
        public string cardName;
        public buffDuration durationOfBuff;
        public buffEffectCondition effectedValueType;
        public float effectValueAdded;
        public buffEffectdPlayer effectedPlayer;
        public int numberOfUse;
        public combineCardCondition combineCardData;
        public string cardBuffInformations;

    }
    public class deckGlobalClass
    {
     
        public  int deckID;
        public  List<cardID> currentDeck = new List<cardID>(20);
        public  List<cardID> currentDeckLeftCards = new List<cardID>(20);
        public  List<cardID> lastDeck = new List<cardID>(20);
        public  int leftCardsInGame = 20;
        public  bool deckFormed;
        public  bool noLeftCards;
        public  int deckRarityValue;
        public static int CurrentDiamondCards = 0;
        public static int CurrentGoldCards = 0;
        public static int CurrentSilverCards = 0;
        public static int CurrentBronzeCards = 0;

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
    public static int DiamondLimit=3;
    public static int GoldLimit = 4;
    public static int SilverLimit = 7;
    public static int BronzeLimit = 6;

    public static int CurrentDiamondCards = 0;
    public static int CurrentGoldCards = 0;
    public static int CurrentSilverCards = 0;
    public static int CurrentBronzeCards = 0;

    public static List<string> cardsTexturesPaths = new List<string>();
    public static List<Sprite> cardsTextureSprites = new List<Sprite>();
    public static  string cardsFolderPath;
    

}
