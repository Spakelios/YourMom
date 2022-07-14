using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
 

    public SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;
   
    public KeyCode KeyToPress;

    private void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyToPress))
        {
            theSR.sprite = pressedImage;
        }

        if (Input.GetKeyUp(KeyToPress))
        {
            theSR.sprite = defaultImage;
        }
    }
}