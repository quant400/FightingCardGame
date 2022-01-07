
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
        public  deckModel.deckGlobalClass InGamePlayersDeckModel = new deckModel.deckGlobalClass();
        public fighterModel.fighterData fighterData = new fighterModel.fighterData();
    }
    public static List<playerDecksModels> InGamePlayersDeckModels = new List<playerDecksModels>();

}
