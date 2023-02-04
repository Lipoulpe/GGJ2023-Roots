using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    PickingSeed,
    ThrowingSeed,
    SeedStopMoving,
    GrowingSeed,
    EndGrowth
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState State;

    public static event Action<GameState> OnGameChanged;

    public float HorizontalStrengh = 500f;
    public float VerticalStrengh = 200f;

    public SeedBehaviour CurrentSeed;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateGameState(GameState.PickingSeed);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch(newState)
        {
            case GameState.GrowingSeed:
                break;

        }

        OnGameChanged?.Invoke(newState);
    }

    public void Throw()
    {
        UpdateGameState(GameState.ThrowingSeed);
    }
}
