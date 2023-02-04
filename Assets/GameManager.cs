using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public float HorizontalStrengh;

    public Slider Strenght;
    public SeedBehaviour Seed;

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
                IEnumerator Growing()
                {
                    yield return new WaitForSeconds(1);
                    UpdateGameState(GameState.PickingSeed);
                }

                StartCoroutine(Growing());
                break;

        }

        OnGameChanged?.Invoke(newState);
    }

    public void Throw()
    {
        HorizontalStrengh = Strenght.value;
        UpdateGameState(GameState.ThrowingSeed);
    }

    public void PickedSeed(SeedBehaviour seed_0)
    {
        Seed.SeedNextStage = seed_0.SeedNextStage;
        Seed.Rigidbody.gravityScale = seed_0.Rigidbody.gravityScale;

        Seed.SpriteRenderer.sprite = seed_0.SpriteRenderer.sprite;
    }

}
