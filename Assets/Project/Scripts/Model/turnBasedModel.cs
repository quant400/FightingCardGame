
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;
using UniRx.Triggers;
using UniRx.Toolkit;
[Serializable]

public struct turnBasedModel
{
   
    public enum turnbasedPlayerStates
    {
        gameStart,
        playerOneTrun,
        PlayerTwoTrun,
        gameDone,
    };
    public enum turnbasedPlayingStates
    {
        onAutoDrawStart,
        onDraw,
        onPlayCard,
        onReadyTobuff,
        onAttack,
        onBuff,
        onFinishTurn,
    };
    public static ReactiveProperty<turnbasedPlayerStates> currentPlayerTurn = new ReactiveProperty<turnbasedPlayerStates>();
    public static ReactiveProperty<turnbasedPlayingStates> currentPlayingState = new ReactiveProperty<turnbasedPlayingStates>();


}
