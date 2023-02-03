using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private SeedBehaviour _Seed;

    [SerializeField] CameraMovements _Camera;

    private void Awake()
    {
        Instance = this;
    }

    public void Throw(SeedBehaviour seed)
    {
        //Camera


        //Seed
        seed.Rigidbody.simulated = true;
        seed.Rigidbody.AddForce(new Vector2(500, 200),ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {

    }
}
