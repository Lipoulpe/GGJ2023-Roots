using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    PickingSeed,
    Thrown,
    AfterThrow
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState State;

    public static event Action<GameState> OnGameChanged;

    [SerializeField] private SeedBehaviour _Seed;

    public float _HorizontalStrengh = 500f;
    public float _VerticalStrengh = 200f;

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
            case GameState.AfterThrow:
                _Seed.Rigidbody.simulated = false;
                _Seed.Reset();
                break;
        }

        OnGameChanged?.Invoke(newState);
    }

    public void Throw()
    {
        UpdateGameState(GameState.Thrown);
        //Seed
        _Seed.Rigidbody.simulated = true;
        _Seed.Rigidbody.AddForce(new Vector2(_HorizontalStrengh, _VerticalStrengh),ForceMode2D.Impulse);
    }

 
}
