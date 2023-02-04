using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceSeed : SeedBehaviour
{
    [SerializeField] float _HorizontaleBounce;
    [SerializeField] float _VerticaleBounce;

    void NextStep()
    {
        GameObject go = Instantiate(SeedNextStage, SeedsParent.transform);
        go.transform.position = transform.position;
        go.GetComponent<BounceSeed>().SeedsParent = SeedsParent;

        Destroy(gameObject);
    }

    public override void Growing()
    {
        if (SeedNextStage == null) return;

        NextStep();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Seed")
        {
            collision.attachedRigidbody.AddForce(new Vector2(_HorizontaleBounce, _VerticaleBounce), ForceMode2D.Impulse);
        }
    }
}
