using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private SeedBehaviour _Seed;
    [SerializeField] private BoxCollider2D _SkyHitBox;
    [SerializeField] private BoxCollider2D _GroundHitBox;

    private void Awake()
    {
        Instance = this;
    }

    public void Throw(SeedBehaviour seed)
    {
        seed.Rigidbody.simulated = true;
        seed.Rigidbody.AddForce(new Vector2(500, 200),ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {

    }
}
