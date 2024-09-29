using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class KitchenGameManager : MonoBehaviour
{





    public event EventHandler OnStateCanged;
    public event EventHandler OnGamePaused;
    public event EventHandler OnGameUnPaused;
    public static KitchenGameManager instance {  get; private set; }
    private enum State
    {
        WaitingToStart,
        CountDownToStart,
        GamePlaying,
        GameOver,
    }

    

    private State state;
    private float waitingToStateTimer = 1f;
    private float countToStateTimer = 3f;
    private float gamePlaingTimer;
    private float gamePlaingTimerMax = 100f;
    private bool isGamePaused = false;


    private void Awake()
    {
        instance = this;
        state = State.WaitingToStart;
    }

    private void Start()
    {
      


        GameInput.Instance.OnPauseAction += GameInput_OnPauseAction;    
    }

    private void GameInput_OnPauseAction(object sender, EventArgs e)
    {
        TogglePauseGame();
        

    }

    private void Update()
    {
        switch (state)
        {
            case State.WaitingToStart:

                waitingToStateTimer -= Time.deltaTime;

                if(waitingToStateTimer < 0f)
                {
                    state = State.CountDownToStart;

                    OnStateCanged?.Invoke(this, EventArgs.Empty);
                }

                break;

            case State.CountDownToStart:

                countToStateTimer -= Time.deltaTime;

                if (countToStateTimer < 0f)
                {
                    state = State.GamePlaying;
                    gamePlaingTimer = gamePlaingTimerMax;
                    OnStateCanged?.Invoke(this, EventArgs.Empty);
                }

                break;
            case State.GamePlaying:

                gamePlaingTimer -= Time.deltaTime;

                if (gamePlaingTimer < 0f)
                {
                    state = State.GameOver;
                    OnStateCanged?.Invoke(this, EventArgs.Empty);
                }

                break;
            case State.GameOver:
         

                break;
        }

      
    }

    public bool IsGamePlaying()
    {
        return state == State.GamePlaying;
    }
    
    public bool IsCountDownToStartActive()
    {
        return state == State.CountDownToStart;
    }
    
    public float GetCountDownToStartTimer()
    {
        return countToStateTimer;
    }

    public bool IsGameOver()
    {
        return state == State.GameOver;

    }

    public float GetGamePlayingTimerNormalized()
    {
        return 1- (gamePlaingTimer / gamePlaingTimerMax);
    }

    public void TogglePauseGame()
    {
        isGamePaused = !isGamePaused;
        if (isGamePaused)
        {
            Time.timeScale = 0f;
            OnGamePaused?.Invoke(this, EventArgs.Empty);
            
        }
        else
        {
            Time.timeScale = 1f;
            OnGameUnPaused?.Invoke(this, EventArgs.Empty);
        }
       
    }

    public void AddTimeToGame(float extraTime)
    {
        gamePlaingTimer += extraTime;
    }


}
