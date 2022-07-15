using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NoteArea : MonoBehaviour
{
    public bool canBePRessed;
    public KeyCode keyToPress;

    public GameObject  goodEffect, greatEffect, perfectEffect, missedEffect;

    private void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePRessed)
            {
                gameObject.SetActive(false);
                //GameManager.instance.NoteHit();

                if (Mathf.Abs(transform.position.y) > 0.25f)
                {
                    Debug.Log("hit");
                    GameManager.instance.NormalHit();
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                }
                else if (Mathf.Abs(transform.position.y) > 0.05f)
                {
                    Debug.Log("good");
                    GameManager.instance.GoodHit();
                    Instantiate(greatEffect, transform.position, greatEffect.transform.rotation);
                }
                else 
                {
                    Debug.Log("perfect!");
                    GameManager.instance.PerfectHit();
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                }
                    
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Button"))
        {
            canBePRessed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Button"))
        {
            canBePRessed = false;

            GameManager.instance.NoteMissed();
        }
    }
}