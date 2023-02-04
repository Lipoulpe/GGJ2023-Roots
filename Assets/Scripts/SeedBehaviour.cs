using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedBehaviour : MonoBehaviour
{
    public event Action OnReset;

    public SpriteRenderer SpriteRenderer;
    public Rigidbody2D Rigidbody;
    public GameObject SeedsParent;

    [Header("Seed Settings")]
    public int ThrowBeforeGrowth;
    public float GravityScale;
    public GameObject SeedNextStage;
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

    public void OnOnGameChanged(GameState newState)
    {
        if (newState == GameState.ThrowingSeed && !IsRooted)
        {
            Throw();
        }
        if (newState == GameState.SeedStopMoving && !IsRooted)
        {
            GenerateSeed();
            GameManager.Instance.UpdateGameState(GameState.GrowingSeed);
        }
        if(newState == GameState.GrowingSeed && IsRooted)
        {
            Growing();
        }

        if (newState == GameState.EndGrowth && !IsRooted)
        {
            GameManager.Instance.UpdateGameState(GameState.PickingSeed);
        }
    }

    public void Throw()
    {
        //Seed
        Rigidbody.simulated = true;
        Rigidbody.AddForce(new Vector2(GameManager.Instance.HorizontalStrengh, 5f), ForceMode2D.Impulse);
    }
    public void Reset()
    {
        Rigidbody.simulated = false;
        transform.position = _startingPosition;
        transform.rotation = Quaternion.identity;
        OnReset?.Invoke();
    }

    void GenerateSeed()
    {
        GameObject go = Instantiate(SeedNextStage, SeedsParent.transform);
        go.transform.position = transform.position;
        go.GetComponent<SeedBehaviour>().SeedsParent = SeedsParent;

        Reset();
    }

    public virtual void Growing()
    {

    }

}
