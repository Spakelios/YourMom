using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oop : MonoBehaviour
{
    public GameObject youmom;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Button"))
        {
            Destroy(youmom);
        }
    }
}

