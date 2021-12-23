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
    public class fighterDataValueClass
    {
        public string valueName;
        public float value;
    }
    public class fighterData
    {
        public string fighterName;
        public float id;
        public List<wearables> currentWearablesSelected = new List<wearables>();
        public fighterDataValueClass addedPowerLevel = new fighterDataValueClass();
        public fighterDataValueClass fighterAttackLevel;
        public fighterDataValueClass fighterDefenceLevel;
        public fighterDataValueClass fighterSpeed;
        public fighterDataValueClass fighterResistnace;
        public fighterDataValueClass fighterTechniqueLevel;
        public fighterDataValueClass accerancypercentage;
        public string emoteAniamtionName;
        public string fighterDescription;
        public fighterDataValueClass fighterRarityValue;
        public fighterDataValueClass critcalHitCondition;
        public GameObject fighterPrefab;
        public Texture2D fighterIcon;
        public fighterDataValueClass fighterHealth ;
        public fighterDataValueClass fighterLeftHealth;
        public fighterDataValueClass fighterStartStamina;
        public fighterDataValueClass fighterRoundAddedStamina;
        public fighterDataValueClass fighterCurrentStamina;
        public fighterDataValueClass fighterLeftEnegy;
        public fighterDataValueClass fighterShieldLeftPower;
        public List<fighterDataValueClass> effectValuesList=new List<fighterDataValueClass>();
        public bool owned;
        
    }
    public static float fighterStartHealth = 4000;
    public static float fighterLeftHealthz;
    public static float fighterStartStamina = 3;
    public static float fighterRoundAddedStamina = 1;
    public static float fighterCurrentStamina;
    public static float fighterLeftEnegy;
    public static float fighterShieldLeftPower;
    public static fighterData currentChosenFighter = new fighterData();
    public static fighterData lastUsedFighter = new fighterData();

}
