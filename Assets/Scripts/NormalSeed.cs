using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSeed : SeedBehaviour
{

    public override void OnOnGameChanged(GameState newState)
    {
        if (newState == GameState.ThrowingSeed && !IsRooted)
        {
            Throw();
        }
        if(newState == GameState.SeedStopMoving && !IsRooted)
        {
            GenerateSeed();
            GameManager.Instance.UpdateGameState(GameState.GrowingSeed);
        }
        if (newState == GameState.GrowingSeed && IsRooted)
        {
            Growing();
        }
    }


    void Growing()
    {
        if (SeedNextStage != null)
        {
            
        }

    }

    void GenerateSeed()
    {
        GameObject go = Instantiate(SeedNextStage, SeedsParent.transform);
        go.transform.position = transform.position;
        NormalSeed seed = go.GetComponent<NormalSeed>();

        seed.Growing();

        Reset();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Seed")
        {
            
        }
    }
}
