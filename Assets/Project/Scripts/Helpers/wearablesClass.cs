using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;
using UniRx.Triggers;
using UniRx.Operators;
using System.Linq;
public class wearablesClass : MonoBehaviour
{
    public fighterModel.wearables warablesData;
    public bool wearableChoosen;
    public void Start()
    {
        warablesData = new fighterModel.wearables();
        warablesData.id = UnityEngine.Random.Range(0, 999);


    }
    public void setFighterItemToDataBase()
    {
        if (!wearableChoosen)
        {
            fighterModel.wearables searchedFile = fighterModel.currentChosenFighter.currentWearablesSelected.Find(x => x.type == warablesData.type);
            if (searchedFile != null)
            {
                fighterModel.currentChosenFighter.currentWearablesSelected.Remove(searchedFile);
                fighterModel.currentChosenFighter.currentWearablesSelected = fighterModel.currentChosenFighter.currentWearablesSelected.Where(x => x != null).ToList();

            }
            fighterModel.currentChosenFighter.currentWearablesSelected.Add(warablesData);
            //send message here to database with fighterID 
            wearableChoosen = true;
        }

    }
}
