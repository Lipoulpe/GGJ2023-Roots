using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSeedCamera : MonoBehaviour
{
    public Transform Seed;
    Vector3 _startingPosition;

    private void Start()
    {
        _startingPosition = new Vector3(transform.position.x,transform.position.y,transform.position.z);
        GameManager.OnGameChanged += ResetPos;
    }

    private void OnDestroy()
    {
        GameManager.OnGameChanged -= ResetPos;
    }
    void Update()
    {
        if (GameManager.Instance.State != GameState.ThrowingSeed) return;

        transform.position = new Vector2(Seed.position.x, Seed.position.y);
    }

    private void ResetPos(GameState state)
    {
        if(state == GameState.PickingSeed)
        {
            transform.position = _startingPosition;
        }
    }
}
