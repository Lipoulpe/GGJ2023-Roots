using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampSeed : SeedBehaviour
{
    void NextStep()
    {
        GameObject go = Instantiate(SeedNextStage, SeedsParent.transform);
        go.transform.position = transform.position;
        go.GetComponent<RampSeed>().SeedsParent = SeedsParent;

        Destroy(gameObject);
    }

    public override void Growing()
    {
        if (SeedNextStage == null) return;

        NextStep();

    }
}
