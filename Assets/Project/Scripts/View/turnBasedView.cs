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
public class turnBasedView : MonoBehaviour
{
    public ReactiveProperty<int> currentPlayer = new ReactiveProperty<int>();
    public deckLoadView _deckLoadView;
    public bool otherPlayerCanBuff;
    public float playCardCounterDuration=20;
    public float attackCounterDuration=15;
    public float buffCounterDuration=10;
    public ReactiveProperty<float> countdownTimer= new ReactiveProperty<float>();
    public ReactiveProperty<int> currentTurnStep = new ReactiveProperty<int>();
    public Text counterText;
    public Button goToNextDebugBtn;
    public Text currentPlayerTurnText;
    // Start is called before the first frame update
    void Start()
    {
        countdownTimer.Value = 60;
        currentTurnStep.Value = 0;
        currentPlayer.Value = -1;
        observeTurnBased();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void observeTurnBased()
    {
        turnBasedModel.currentPlayerTurn
               .Subscribe(procedeTurnObserve)
               .AddTo(this);
        void procedeTurnObserve(turnBasedModel.turnbasedPlayerStates status)
        {
            switch (status)
            {
                case turnBasedModel.turnbasedPlayerStates.gameStart:
                    InitializeTurns();
                    break;
                case turnBasedModel.turnbasedPlayerStates.playerOneTrun:
                    currentPlayerTurnText.text = "Player One Turn";
                    turnBasedModel.currentPlayingState.Value = turnBasedModel.turnbasedPlayingStates.onDraw;
                    break;
                case turnBasedModel.turnbasedPlayerStates.PlayerTwoTrun:
                    currentPlayerTurnText.text = "Player two Turn";
                    turnBasedModel.currentPlayingState.Value = turnBasedModel.turnbasedPlayingStates.onDraw;
                    break;
            }
        }
        currentPlayer
            .Where(_=>_>=0)
            .Do(_ => setCurrentPlayer(_))
            .Subscribe()
            .AddTo(this);
        observePlayerTurnState();
    }
    public void observePlayerTurnState()
    {
        turnBasedModel.currentPlayingState
              .Subscribe(procedeTurnObserve)
              .AddTo(this);
        void procedeTurnObserve(turnBasedModel.turnbasedPlayingStates status)
        {
            switch (status)
            {
                case turnBasedModel.turnbasedPlayingStates.onDraw:
                    if (_deckLoadView != null)
                    {
                        _deckLoadView.loadTurnCard(1, fightView.fighters[currentPlayer.Value].playerDeckInGame);

                    }
                    goToNextStepWithAction();
                    break;
                case turnBasedModel.turnbasedPlayingStates.onPlayCard:
                    StartCoroutine(Countdown(playCardCounterDuration));
                    break;
                case turnBasedModel.turnbasedPlayingStates.onAttack:
                    StartCoroutine(Countdown(attackCounterDuration));
                    break;
                case turnBasedModel.turnbasedPlayingStates.onBuff:
                    StartCoroutine(Countdown(buffCounterDuration));
                    break;
                case turnBasedModel.turnbasedPlayingStates.onReadyTobuff:
                    otherPlayerCanBuff = true;
                    StartCoroutine(Countdown(buffCounterDuration));
                    break;
                case turnBasedModel.turnbasedPlayingStates.onFinishTurn:
                    currentPlayer.Value = switchPlayer(currentPlayer.Value);
                    currentTurnStep.Value = 0;
                    break;
            }
        }
        
        currentTurnStep
            .Where(_ => _ != 0)
            .Do(_ => setStateFromStep(_))
            .Subscribe()
            .AddTo(this);
        goToNextDebugBtn.OnClickAsObservable()
            .Do(_ => goToNextStepWithAction())
            .Subscribe()
            .AddTo(this);

    }
    public void goToNextStepWithAction()
    {
        StopAllCoroutines();
        StopCoroutine("Countdown");
        currentTurnStep.Value++;
        counterText.text = "waiting...";
    }
    public void InitializeTurns()
    {
        currentPlayer.Value = switchPlayer(currentPlayer.Value);
    }
    
    public void InitializePlayingState()
    {

    }
    void setStateFromStep(int step)
    {
        switch (step)
        {
            case 1:
                turnBasedModel.currentPlayingState.Value = turnBasedModel.turnbasedPlayingStates.onPlayCard;
                break;
            case 2:
                turnBasedModel.currentPlayingState.Value = turnBasedModel.turnbasedPlayingStates.onAttack;
                break;
            case 3:
                turnBasedModel.currentPlayingState.Value = turnBasedModel.turnbasedPlayingStates.onBuff;
                break;
            case 4:
                turnBasedModel.currentPlayingState.Value = turnBasedModel.turnbasedPlayingStates.onReadyTobuff;
                break;
            case 5:
                turnBasedModel.currentPlayingState.Value = turnBasedModel.turnbasedPlayingStates.onFinishTurn;
                break;

        }
    }
    public void setCurrentPlayer(int value)
    {
        if (value == 0)
        {
            turnBasedModel.currentPlayerTurn.Value = turnBasedModel.turnbasedPlayerStates.playerOneTrun;
        }
        else if(value==1)
        {
            turnBasedModel.currentPlayerTurn.Value = turnBasedModel.turnbasedPlayerStates.PlayerTwoTrun;
        }
      
    }
    public int switchPlayer(int current)
    {
        if (current != 0)
        {
            return 0;
        }
        else return 1;
    }
    private IEnumerator Countdown2(float duration)
    {
           //to whatever you want
        float normalizedTime = 0;
        while (normalizedTime <= 1f)
        {
            countdownTimer.Value = duration-Time.deltaTime;
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }
    }
    private IEnumerator Countdown(float duration)
    {
        while (duration >= 1)
        {
            duration--;
            yield return new WaitForSeconds(1);
            countdownTimer.Value = duration;
            counterText.text = countdownTimer.Value.ToString() + " S left";
        }
        Debug.Log("Countdown Complete!");
        currentTurnStep.Value++;
        counterText.text = "waiting...";
    }
}
