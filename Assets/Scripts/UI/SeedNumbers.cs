using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SeedNumbers : MonoBehaviour
{
    [SerializeField] SeedAttribute _Seed;

    [SerializeField] TextMeshProUGUI _Text;

    private void Start()
    {
        _Seed.OnSeedNumberChange += UpdateNumber;
    }

    private void OnDestroy()
    {
        _Seed.OnSeedNumberChange -= UpdateNumber;
    }

    void UpdateNumber()
    {
        _Text.text = _Seed.SeedNumber.ToString();
    }
}
