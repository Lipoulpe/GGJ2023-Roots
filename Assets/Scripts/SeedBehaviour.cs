using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedBehaviour : MonoBehaviour
{
    public event Action OnReset;

    public Rigidbody2D Rigidbody;
    public GameObject SeedsParent;

    [Header("Seed Settings")]
    public int ThrowBeforeGrowth;
    public float GravityScale;
    public GameObject[] SeedPrefab;
    public bool IsRooted = false;



    Vector2 _startingPosition;

    private void Start()
    {
        GameManager.OnGameChanged += OnOnGameChanged;

        _startingPosition = transform.position;
        Rigidbody.gravityScale = GravityScale;
    }

    private void OnDestroy()
    {
        GameManager.OnGameChanged -= OnOnGameChanged;
    }
    void StopMoving()
    {
        if (Rigidbody.velocity.x <= 10 && Rigidbody.velocity.y <= 10) GameManager.Instance.UpdateGameState(GameState.SeedStopMoving);
    }
    private void Update()
    {
        if (GameManager.Instance.State == GameState.ThrowingSeed && !IsRooted)StopMoving();

    }

    public void Throw()
    {
        //Seed
        Rigidbody.simulated = true;
        Rigidbody.AddForce(new Vector2(GameManager.Instance.HorizontalStrengh, GameManager.Instance.VerticalStrengh), ForceMode2D.Impulse);
    }
    public void Reset()
    {
        Rigidbody.simulated = false;
        transform.position = _startingPosition;
        OnReset?.Invoke();

        GameManager.Instance.UpdateGameState(GameState.PickingSeed);
    }

    public virtual void OnOnGameChanged(GameState newState)
    {

    }

}
