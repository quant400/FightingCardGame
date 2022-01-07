using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropArea : MonoBehaviour,IDropHandler {

    [SerializeField]
    CardManager cardManager;
    [SerializeField]
    int playerNumber;
    public void OnDrop(PointerEventData eventData)
    {
        PlayerCard pc;
        if (eventData.pointerDrag == null) return;
        pc = eventData.pointerDrag.GetComponent<PlayerCard>();
        if (!pc) return;
        if(pc.cardOwner != playerNumber)
        {
            print("Cannot drop on other player's area?");
            return;
        }
        pc.transform.SetParent(transform);
        cardManager.UpdateTurn();
    }
}
