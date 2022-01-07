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

    [SerializeField] fightView _fightView;
    [SerializeField] deckLoadView _deckLoadView;
    float localValue;
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
                for (int i = 0; i < fightView.fighters.Count; i++)
                {
                    if (!fightView.fighters[i].isMine)
                    {
                        cardBuff(card.buffEffectData, fightView.fighters[i]);
                    }

                }
            }
            else if (card.buffEffectData.effectedPlayer == deckModel.buffEffectdPlayer.self)
            {
                for (int i = 0; i < fightView.fighters.Count; i++)
                {
                    if (fightView.fighters[i].isMine)
                    {
                        cardBuff(card.buffEffectData, fightView.fighters[i]);

                    }

                }
            }
            else if (card.buffEffectData.effectedPlayer == deckModel.buffEffectdPlayer.allPlayers)
            {
                for (int i = 0; i < fightView.fighters.Count; i++)
                {
                    cardBuff(card.buffEffectData, fightView.fighters[i]);
                }
            }
        }
    }
    public void cardBuff(deckModel.cardBuffEffect buffEffect , fightView.fighterInGame fighter)
    {
        if (buffEffect.effectedPlayer == deckModel.buffEffectdPlayer.otherPlayer)
        {
            switch (buffEffect.effectedValueType.type)
            {
                case deckModel.buffEffectedValueType.damage:
                    buffValue(buffEffect.effectedValueType.valueAddedDetails, buffEffect.effectValueAdded, fighter, buffEffect, buffEffect.effectedValueType.type.ToString());
                    _fightView.hitAction(fighter.playerID, GameModel.targetHitValue.bothDirect, localValue);
                    break;
                case deckModel.buffEffectedValueType.defence:
                    buffValue(buffEffect.effectedValueType.valueAddedDetails, buffEffect.effectValueAdded, fighter, buffEffect, buffEffect.effectedValueType.type.ToString());
                    break;
                case deckModel.buffEffectedValueType.technique:
                    buffValue(buffEffect.effectedValueType.valueAddedDetails, buffEffect.effectValueAdded, fighter, buffEffect, buffEffect.effectedValueType.type.ToString());
                    break;
                case deckModel.buffEffectedValueType.energy:
                    buffValue(buffEffect.effectedValueType.valueAddedDetails, buffEffect.effectValueAdded, fighter, buffEffect, buffEffect.effectedValueType.type.ToString());
                    break;
                case deckModel.buffEffectedValueType.shield:
                    buffValue(buffEffect.effectedValueType.valueAddedDetails, buffEffect.effectValueAdded, fighter, buffEffect, buffEffect.effectedValueType.type.ToString());
                    if (buffEffect.effectedValueType.valueAddedDetails == deckModel.valueAddedType.ignore)
                    {
                        _fightView.hitAction(fighter.playerID, GameModel.targetHitValue.health, localValue);

                    }
                    else if (buffEffect.effectedValueType.valueAddedDetails == deckModel.valueAddedType.normal)

                    {
                        _fightView.hitAction(fighter.playerID, GameModel.targetHitValue.shield, localValue);
                    }

                    break;
                case deckModel.buffEffectedValueType.strike:
                    buffValue(buffEffect.effectedValueType.valueAddedDetails, buffEffect.effectValueAdded, fighter, buffEffect, buffEffect.effectedValueType.type.ToString());
                    _fightView.hitAction(fighter.playerID, GameModel.targetHitValue.bothDirect, localValue);
                    break;
                case deckModel.buffEffectedValueType.heal:
                    buffValue(buffEffect.effectedValueType.valueAddedDetails, buffEffect.effectValueAdded, fighter, buffEffect, buffEffect.effectedValueType.type.ToString());
                    _fightView.hitAction(fighter.playerID, GameModel.targetHitValue.bothDirect, localValue);
                    break;
                case deckModel.buffEffectedValueType.drawCard:
                    buffValue(buffEffect.effectedValueType.valueAddedDetails, buffEffect.effectValueAdded, fighter, buffEffect, buffEffect.effectedValueType.type.ToString());
                    drawCardBuff(buffEffect.effectedValueType.type.ToString(), fighter);
                    break;
                case deckModel.buffEffectedValueType.Debuff:
                    buffValue(buffEffect.effectedValueType.valueAddedDetails, buffEffect.effectValueAdded, fighter, buffEffect, buffEffect.effectedValueType.type.ToString());
                    break;
                case deckModel.buffEffectedValueType.hit:
                    buffValue(buffEffect.effectedValueType.valueAddedDetails, buffEffect.effectValueAdded, fighter, buffEffect, buffEffect.effectedValueType.type.ToString());
                    _fightView.hitAction(fighter.playerID, GameModel.targetHitValue.bothDirect, localValue);
                    break;
                case deckModel.buffEffectedValueType.invalidCard:
                    buffValue(buffEffect.effectedValueType.valueAddedDetails, buffEffect.effectValueAdded, fighter, buffEffect, buffEffect.effectedValueType.type.ToString());
                    break;
                case deckModel.buffEffectedValueType.healFromCardDamage:
                    buffValue(buffEffect.effectedValueType.valueAddedDetails, buffEffect.effectValueAdded, fighter, buffEffect, buffEffect.effectedValueType.type.ToString());
                    break;
                case deckModel.buffEffectedValueType.removeCardFromHand:
                    buffValue(buffEffect.effectedValueType.valueAddedDetails, buffEffect.effectValueAdded, fighter, buffEffect, buffEffect.effectedValueType.type.ToString());
                    removeCardFromHand(fighter.playerID, 1);
                    break;
                case deckModel.buffEffectedValueType.allDrawCard:
                    if (buffEffect.effectedValueType.valueAddedDetails == deckModel.valueAddedType.normal)

                    {
                        for (int i = 0;i < fightView.fighters.Count; i++)
                        {
                            fighter = fightView.fighters[i];
                            drawCardBuff(buffEffect.effectedValueType.type.ToString(), fighter);

                        }
                    }
                    break;
                case deckModel.buffEffectedValueType.cretical:
                    buffValue(buffEffect.effectedValueType.valueAddedDetails, buffEffect.effectValueAdded, fighter, buffEffect, buffEffect.effectedValueType.type.ToString());
                    if (critiaclStrikeChanceCalulation(50))
                    {
                        _fightView.hitAction(fighter.playerID, GameModel.targetHitValue.bothDirect, localValue);
                    }
                    break;
            }
        }
    }
    public void buffValue(deckModel.valueAddedType valueAddType, float value, fightView.fighterInGame effectedPlayer, deckModel.cardBuffEffect buffData,string effectedName)
    {
        if (valueAddType == deckModel.valueAddedType.down)
        {
            localValue = value * -1;
        }
        else if (valueAddType == deckModel.valueAddedType.up)
        {
        }

        else if (valueAddType == deckModel.valueAddedType.multi)
        {
            for (int i = 0; i < fightView.fighters.Count; i++)
            {
                localValue += value;
            }
        }        
    }
    void fighterValueBuff(fightView.fighterInGame fighter , float valueAdded , string effectedValueName )
    {
        for(int i = 0; i < fighter.fighterData.effectValuesList.Count; i++)
        {
            if (effectedValueName.Equals(fighter.fighterData.effectValuesList[i].valueName))
            {
                fighter.fighterData.effectValuesList[i].value += valueAdded;
            }
        }
    }
    public void removeCardFromHand(int id,int numberOfCards)
    {

        _fightView.removeCard(id, numberOfCards);

    }
    public void drawCardBuff(string buffStringName,  fightView.fighterInGame cardPlayer)
    {
        _deckLoadView.loadTurnCard(1, cardPlayer.playerDeckInGame);
    }
    public void addOrLowerDamage(fightView.fighterInGame damagedPlayer,bool add)
    {

    }
    public void addOrLowerTech(fightView.fighterInGame addedToPlayer,bool add)
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
    public void addOrLowerEnergy(fightView.fighterInGame addedToPlayer, bool add)
    {

    }
    public void strike()
    {

    }
    public void blockAndHeal()
    {

    }
    public void ignoreShield(fightView.fighterInGame player)
    {
        player.targetHealth.Value= GameModel.targetHitValue.health;
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
