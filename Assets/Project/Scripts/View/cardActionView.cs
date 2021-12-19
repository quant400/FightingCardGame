using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;
using UniRx.Triggers;
using UniRx.Operators;
using System.Linq;
using System.IO;
public class cardActionView : MonoBehaviour
{
    public class fighterInGame
    {
        public int playerID;
        public fighterModel.fighterData fighterData;
        public List<deckModel.cardID> deckOwned;
        public List<deckModel.cardID> deckLeftCards;
        public List<deckModel.cardID> inHandsCards;

    }

    public List<fighterInGame> fighters = new List<fighterInGame>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void cardBuff(string buffStringName, deckModel.cardID cardPlayed , fighterInGame cardPlayer)
    {

    }
    public void addOrLowerDamage(fighterInGame damagedPlayer,bool add)
    {

    }
    public void addOrLowerTech(fighterInGame addedToPlayer,bool add)
    {

    }
    public void addorLowerShieldValue()
    {

    }
    public void critcalStrike()
    {

    }
    public bool critiaclStrikeChanceCalulation(int percentage)
    {
        int critiaclvalue = 0 + percentage;
        int critiaclvaluecalculation=UnityEngine.Random.Range(0,100);
        if (critiaclvalue >=100)
        {
            return true;
        }
        else 
        {
            if (critiaclvaluecalculation > (100 - percentage))
            {
                return true;

            }
            else
            {
                return false;

            }
        } 
    }
    public void addOrLowerEnergy(fighterInGame addedToPlayer, bool add)
    {

    }
    public void strike()
    {

    }
    public void blockAndHeal()
    {

    }
    public void ignoreShield()
    {

    }
    public void addOrLowerHeal()
    {

    }
    public void critcalOrHitSelf()
    {

    }
    public void addOrLowerAttack()
    {

    }
    public void multiHits(int number)
    {
        for (int i=0; i < number; i++)
        {
            strike();
        }
    }
    public void multiAttackOnShield()
    {

    }
}
