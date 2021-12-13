using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;
using UniRx.Triggers;
using UniRx.Toolkit;
[Serializable]
public struct fighterModel
{
    public enum wearablesTypes
    {
        shorts,
        gloves,
        belt,
        lionHeart,
        hat,
        chain,
    }
    public class wearables
    {
        public wearablesTypes type;
        public int id;
        public float powerLevel;
        public int tokenPrice;
        public string discription;
        public GameObject wearablesPrefab;
        public Texture2D wearablesIcon;
        public bool owned;
    }
    public class fighterData
    {
        public string fighterName;
        public float id;
        public List<wearables> currentWearablesSelected = new List<wearables>();
        public float addedPowerLevel;
        public float punchPower;
        public float defencePower;
        public float fighterSpeed;
        public float fightResistnace;
        public float accerancypercentage;
        public string emoteAniamtionName;
        public string fighterDescription;
        public GameObject fighterPrefab;
        public Texture2D fighterIcon;

        public bool owned;
        
    }
    public static float fighterHealth = 4000;
    public static float fighterLeftHealth ;
    public static float fighterStartStamina = 3;
    public static float fighterRoundAddedStamina = 1;
    public static float fighterCurrentStamina ;
    public static fighterData currentChosenFighter = new fighterData();
    public static fighterData lastUsedFighter = new fighterData();

}
