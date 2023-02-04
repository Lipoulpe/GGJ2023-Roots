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
    public static event Action OnPickedSeed;

    public float HorizontalStrengh = 500f;
    public float VerticalStrengh = 200f;

    [SerializeField] SeedBehaviour _Seed;

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

    public void PickedSeed(SeedBehaviour seed_0)
    {
        _Seed.SeedNextStage = seed_0.SeedNextStage;
        _Seed.Rigidbody.gravityScale = seed_0.Rigidbody.gravityScale;

        _Seed.SpriteRenderer.sprite = seed_0.SpriteRenderer.sprite;
    }

}
