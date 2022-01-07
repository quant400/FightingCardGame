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
public class fightView : MonoBehaviour
{
    public class fighterInGame
    {
        public int playerID;
        public fighterModel.fighterData fighterData;
        public inGameDeckModels.playerDecksModels playerDeckInGame;
        public List<deckModel.cardID> deckOwned;
        public List<deckModel.cardID> deckLeftCards;
        public List<deckModel.cardID> inHandsCards;
        public List<deckModel.cardID> onUseCards;
        public ReactiveProperty<float> reactiveHealthValue = new ReactiveProperty<float>();
        public ReactiveProperty<float> reactiveShieldValue = new ReactiveProperty<float>();
        public ReactiveProperty<float> reactiveFullHPValue = new ReactiveProperty<float>();


        public ReactiveProperty<GameModel.targetHitValue> targetHealth;
        public bool isMine;
    }
    public static List<fighterInGame> fighters = new List<fighterInGame>();
    // Start is called before the first frame update
    private void Awake()
    {
        for (int i = 0; i < inGameDeckModels.InGamePlayersDeckModels.Count; i++)
        {
            fighters.Add(new fightView.fighterInGame());
            if (fighters[i].playerID == inGameDeckModels.InGamePlayersDeckModels[i].playerId)
            {
                fighters[i].fighterData = inGameDeckModels.InGamePlayersDeckModels[i].fighterData;
                fighters[i].playerDeckInGame = inGameDeckModels.InGamePlayersDeckModels[i];
                fighters[i].deckOwned = inGameDeckModels.InGamePlayersDeckModels[i].InGamePlayersDeckModel.currentDeck;
                fighters[i].deckLeftCards = inGameDeckModels.InGamePlayersDeckModels[i].InGamePlayersDeckModel.currentDeck;
            }
        }
    }
    public void hitAction(int id, GameModel.targetHitValue targetValue, float value)
    {
        for(int i = 0; i < fighters.Count; i++)
        {
            if (fighters[i].playerID == id)
            {
                if (fighters[i].reactiveShieldValue.Value>0)
                    if (targetValue == GameModel.targetHitValue.health)
                    {
                        fighters[i].reactiveShieldValue.Value += value;
                    }
                    else if (targetValue == GameModel.targetHitValue.bothDirect)
                    {
                        if (value < 0)
                        {
                            if(value<=fighters[i].reactiveShieldValue.Value)
                            {
                                fighters[i].reactiveShieldValue.Value += value;

                            }
                            else
                            {
                                float newValue = value - fighters[i].reactiveShieldValue.Value;
                                fighters[i].reactiveShieldValue.Value = 0;
                                fighters[i].reactiveShieldValue.Value += newValue;

                            }

                        }
                        else
                        {
                            fighters[i].reactiveShieldValue.Value += value;
                        }
                    }
                    else if (targetValue == GameModel.targetHitValue.shield)
                    {
                        if (value < 0)
                        {
                            if (value <= fighters[i].reactiveShieldValue.Value)
                            {
                                fighters[i].reactiveShieldValue.Value += value;

                            }
                            else
                            {
                                float newValue = value - fighters[i].reactiveShieldValue.Value;
                                fighters[i].reactiveShieldValue.Value = 0;

                            }
                        }
                        else
                        {
                            fighters[i].reactiveShieldValue.Value += value;
                        }
                    }
            }
        }
        
    }
    public void removeCard(int id, int cardsNumber)
    {
        
        for (int i = 0; i < fighters.Count; i++)
        {
            if (fighters[i].playerID == id)
            {
                for (int j = 0; j < cardsNumber; j++)
                {
                    int rand = UnityEngine.Random.Range(0, fighters[i].inHandsCards.Count);
                    fighters[i].inHandsCards.Remove(fighters[i].inHandsCards[rand]);
                    fighters[i].inHandsCards = fighters[i].inHandsCards.Where(x => x != null).ToList();
                }
            }
        }
    }
    public void inValidCard(int id, int cardsNumber)
    {
        for (int i = 0; i < fighters.Count; i++)
        {
            if (fighters[i].playerID == id)
            {
                for (int j = 0; j < cardsNumber; j++)
                {
                    int rand = UnityEngine.Random.Range(0, fighters[i].onUseCards.Count);
                    fighters[i].onUseCards.Remove(fighters[i].onUseCards[rand]);
                    fighters[i].onUseCards = fighters[i].onUseCards.Where(x => x != null).ToList();
                }
            }
        }
    }

            // Start is called before the first frame update
            void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
