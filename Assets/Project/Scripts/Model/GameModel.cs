
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;
using UniRx.Triggers;
using UniRx.Toolkit;
[Serializable]
public struct GameModel
{
    [Serializable]
    public class userData
    {
        public string userName;
        public string userPassword;
        public string userMetaData;
        public string userEmail;
        public string userSavedDeckData;
        public float ownedTokkens;
        public  List<fighterModel.wearables> ownedWearables = new List<fighterModel.wearables>();
        public  List<fighterModel.fighterData> ownedFighters = new List<fighterModel.fighterData>();

    }
    public enum targetHitValue
    {
        shield,
        health,
        bothDirect,
    };
    [Serializable]
    public enum GameState
    {
        firstLoad,
        InLogin,
        InRegister,
        Registered,
        Logged,
        InMain,
        InShop,
        InRoomMaking,
        InRoom,
        RoomCreated,
        InCharacterSelection,
        CharacterSelected,
        InDeckSelection,
        InDeckForming,
        DeckFormed,
        DeckSelected,
        RoomIsReady,
        InGameStart,
        InQuickTutorial,
        InTutorialDone,
        InGame,
        InGameEnd,
        InTokenMenu,
        InNoInternetPanel,
        
    };
    public static ReactiveProperty<GameState> CurrentGameState = new ReactiveProperty<GameState>();

    public static userData localUserData = new userData();

    public static ReactiveProperty<bool> userLogged = new ReactiveProperty<bool>();

    public static ReactiveProperty<bool> internetCondition = new ReactiveProperty<bool>();
    public static targetHitValue targetHitChoice = targetHitValue.shield;
}