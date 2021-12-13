
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UniRx;
using UniRx.Triggers;
using UniRx.Toolkit;
[Serializable]

public class fighterClass : MonoBehaviour
{
    public fighterModel.fighterData fighterDataObj;
    public bool fighterChoosen;
    public void Start()
    {
        fighterDataObj = new fighterModel.fighterData();
        fighterDataObj.id = UnityEngine.Random.Range(0, 999);
       

    }
    public void setFighterChoosenToDataBase()
    {
        if (!fighterChoosen)
        {
            fighterModel.currentChosenFighter = fighterDataObj;
            //send message here to database with fighterID 
            fighterChoosen = true;
        }
      
    }
}
