using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;

public class NoteArea : MonoBehaviour
{
    public bool canBePRessed;
    public KeyCode keyToPress;

    public GameObject goodEffect, perfectEffect, missedEffect;
    private bool good, bad, perfect;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Button") || other.CompareTag("GOOD") || other.CompareTag("MISSED"))
        {
            canBePRessed = true;
        }

        if (other.CompareTag("GOOD"))
        {
            good = true;
            perfect = false;
            bad = false;
        }
        if (other.CompareTag("Button"))
        {
            perfect = true;
            good = false;
            bad = false;
        }
        if (other.CompareTag("MISSED"))
        {
            bad = true;
            perfect = false;
            good = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePRessed)
            {
                gameObject.SetActive(false);
                //GameManager.instance.NoteHit();

                if (good && !bad && !perfect)
                {
                    Debug.Log("hit");
                    GameManager.instance.NormalHit();
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                }
                if (perfect && !good)
                {
                    Debug.Log("perfect!");
                    GameManager.instance.PerfectHit();
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                }
                if (bad && !good && !perfect)
                {
                    Debug.Log("bad");
                    GameManager.instance.NoteMissed();
                    Instantiate(missedEffect, transform.position, missedEffect.transform.rotation);
                }
            }

        }
    }
}