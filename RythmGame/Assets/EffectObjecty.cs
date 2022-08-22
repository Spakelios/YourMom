using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EffectObjecty : MonoBehaviour
{
    public float lifetime = 1f;

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, lifetime);
    }
}