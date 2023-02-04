using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSeed : SeedBehaviour
{
    void NextStep()
    {
        GameObject go = Instantiate(SeedNextStage, SeedsParent.transform);
        go.transform.position = transform.position;
        go.GetComponent<NormalSeed>().SeedsParent = SeedsParent;

        Destroy(gameObject);
    }

    public override void Growing()
    {
        if (SeedNextStage == null) return;

        NextStep();

    }
}
