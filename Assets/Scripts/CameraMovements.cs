using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovements : MonoBehaviour
{
    [SerializeField] Transform _ZoomIn;
    [SerializeField] Transform _ZoomOut;

    [SerializeField] Transform _RefCamera;
    [SerializeField] SeedBehaviour _Seed;

    void Start()
    {

        transform.position = _RefCamera.position;
        _Seed.OnReset += Reset;

    }

    private void OnDestroy()
    {
        _Seed.OnReset -= Reset;
    }

    private void Update()
    {
        CenterCamera();
    }

    void CenterCamera()
    {
        if (GameManager.Instance.State != GameState.Thrown) return;

        float t = _Seed.Rigidbody.velocity.x / 1000f;


        float x = Mathf.Lerp(_ZoomIn.position.x, _ZoomOut.position.x, t);
        float y = Mathf.Lerp(_ZoomIn.position.y, _ZoomOut.position.y, t);
        float z = Mathf.Lerp(_ZoomIn.position.z, _ZoomOut.position.z, t);

        transform.position = new Vector3(x,y,z);
    }

    private void Reset()
    {
        transform.position = _RefCamera.position;
    }
}
