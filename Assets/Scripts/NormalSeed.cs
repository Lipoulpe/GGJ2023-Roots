using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSeed : SeedBehaviour
{
    private int _growingvalue = 0;

    public override void OnOnGameChanged(GameState newState)
    {
        if (newState == GameState.ThrowingSeed && !IsRooted)
        {
            Throw();
        }
        if(newState == GameState.SeedStopMoving && !IsRooted)
        {
            GenerateSeed();
        }
        if (newState == GameState.GrowingSeed && IsRooted)
        {
            Growing();
        }
    }


    void Growing()
    {
        _growingvalue += 1;
        if (_growingvalue >= ThrowBeforeGrowth) _growingvalue = ThrowBeforeGrowth;

        print(_growingvalue);

    }

    void GenerateSeed()
    {
        GameObject go = Instantiate(SeedPrefab[_growingvalue], SeedsParent.transform);
        go.transform.position = transform.position;
        NormalSeed seed = go.GetComponent<NormalSeed>();

        seed.IsRooted = true;
        seed.Growing();

        GameManager.Instance.UpdateGameState(GameState.GrowingSeed);

        Reset();
    }
}
