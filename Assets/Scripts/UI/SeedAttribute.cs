using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeedAttribute : MonoBehaviour
{
    public Image Image;

    public int SeedNumber;

    public event Action OnSeedNumberChange;

    public void SetSeed(SeedAttribute seed)
    {
        Image.sprite = seed.Image.sprite;
        SeedNumber = seed.SeedNumber;

        OnSeedNumberChange?.Invoke();
    }
}
