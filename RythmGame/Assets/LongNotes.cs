using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class LongNotes : MonoBehaviour
{
    public bool canBePRessed, hold;
    public KeyCode keyToPress;

    public Animator anim;
    public GameObject poo, you;

    public GameObject goodEffect, greatEffect, perfectEffect, missedEffect;


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Button") || other.CompareTag("GOOD"))
        {
            canBePRessed = true;
        }

        if (other.CompareTag("MISSED") && canBePRessed)
        {
            hold = true;
        }
    }

    private void Update()
    {
        if (canBePRessed && Input.GetKey(keyToPress))
        {
            GameManager.instance.NormalHit();
            anim.Play("shoop");
            Debug.Log("hold");
            Invoke("FinishNote", 1f);
        }

       else if (hold)
        {
            Debug.Log("miss!");
            GameManager.instance.NoteMissed();
            Instantiate(missedEffect, transform.position, perfectEffect.transform.rotation);
            Destroy(poo);
            Destroy(you);

        }
        
    }
    void FinishNote()
    {
        Destroy(gameObject);
    }
}

    
