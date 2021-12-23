
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;
using UniRx.Triggers;
using UniRx.Toolkit;
[Serializable]
public struct inGameDeckModels
{
    [Serializable]
    public class playerDecksModels
    {
        public int playerId;
        public string playerName;
        public  List<deckModel> InGamePlayersDeckModel = new List<deckModel>();

    }
    public static List<playerDecksModels> InGamePlayersDeckModel = new List<playerDecksModels>();

}
