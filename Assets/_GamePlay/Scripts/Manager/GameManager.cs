using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState { MainMenu, Gameplay, Pause}

public class GameManager : Singleton<GameManager>
{
  

    private static GameState gameState;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Input.multiTouchEnabled = false;

        // init setting

    }

    public void ChangeState(GameState state)
    {
        gameState = state;
    }

    public bool IsState(GameState state)
    {
        return gameState == state;
    }

}
