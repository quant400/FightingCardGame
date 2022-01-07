using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour {

	public int playerTurn;

    public void UpdateTurn()
    {
        playerTurn = playerTurn == 1 ? 2 : 1;
    }
}
