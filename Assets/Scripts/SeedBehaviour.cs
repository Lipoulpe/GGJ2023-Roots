using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedBehaviour : MonoBehaviour
{
    public event Action OnReset;

    public Rigidbody2D Rigidbody;

    Vector2 _startingPosition;

    private void Start()
    {
        _startingPosition = transform.position;
    }
    void StopMoving()
    {
        if (Rigidbody.velocity.x <= 10 && Rigidbody.velocity.y <= 10) GameManager.Instance.UpdateGameState(GameState.AfterThrow);
    }
    private void Update()
    {
        if (GameManager.Instance.State == GameState.Thrown)StopMoving();

    }

    public void Reset()
    {
        transform.position = _startingPosition;
        OnReset?.Invoke();
    }
}
