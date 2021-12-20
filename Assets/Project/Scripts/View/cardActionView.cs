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
        public bool isMine;
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
    public void cardBuffValueUse(deckModel.cardID card)
    {
        if ((int)card.buffEffectData.effectedValueType.type != 0)
        {
            if (card.buffEffectData.effectedPlayer == deckModel.buffEffectdPlayer.otherPlayer)
            {
                for (int i = 0; i < fighters.Count; i++)
                {
                    if (!fighters[i].isMine)
                    {
                        cardBuff(card.buffEffectData, fighters[i]);
                    }

                }
            }
            else if (card.buffEffectData.effectedPlayer == deckModel.buffEffectdPlayer.self)
            {
                for (int i = 0; i < fighters.Count; i++)
                {
                    if (fighters[i].isMine)
                    {
                        cardBuff(card.buffEffectData, fighters[i]);

                    }

                }
            }
            else if (card.buffEffectData.effectedPlayer == deckModel.buffEffectdPlayer.allPlayers)
            {
                for (int i = 0; i < fighters.Count; i++)
                {
                    cardBuff(card.buffEffectData, fighters[i]);
                }
            }
        }
    }
    public void cardBuff(deckModel.cardBuffEffect buffEffect , fighterInGame fighter)
    {
        if (buffEffect.effectedPlayer == deckModel.buffEffectdPlayer.otherPlayer)
        {
            switch (buffEffect.effectedValueType.type)
            {
                case deckModel.buffEffectedValueType.damage:
                    buffValue(buffEffect.effectedValueType.valueAddedDetails, buffEffect.effectValueAdded, fighter, buffEffect);
                    break;

            }
        }
    }
    public void buffValue(deckModel.valueAddedType valueAddType, float value , fighterInGame effectedPlayer, deckModel.cardBuffEffect buffData)
    {
        
            if (valueAddType == deckModel.valueAddedType.down)
            {
                
                effectedPlayer.fighterData.fighterHealth -= value;
                    
               
            }
            else if (valueAddType == deckModel.valueAddedType.up)
            {
                
                effectedPlayer.fighterData.fighterHealth += value;
              
            }
            else if (valueAddType == deckModel.valueAddedType.multi)
            {
                for (int i = 0; i < fighters.Count; i++)
                {
                    effectedPlayer.fighterData.fighterHealth -= value;
                }
            }



           
       
    }
    //void fighterValueBuff(fighterInGame fighter , float value , deckModel.buff)

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
