using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class GameManager : MonoBehaviour
{
    private int randomise;

    public static GameManager instance;

    public AudioSource theMusic;

    public bool startPLaying;

    public BeatScroller theBS;

    public int currentScore;
    public int ScorePerNote = 100;

    public int ScorePerGoodNote = 125;
    public int ScorePerPerfectNote = 150;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multiplierText;

    public GameObject resultsScreen;
    // public TextMeshProUGUI percentHitText, goodsText, greatsText, perfectsText, missesText, moneyText;
    public float totalHits, goodHits, greatHits, perfectHits, missedHits, percentHit;


    private void Start()
    {
        instance = this;

        scoreText.text = "Score: 0";
        currentMultiplier = 1;
        totalHits = FindObjectsOfType<NoteArea>().Length;
        theMusic.Play();
    }

    private void LateUpdate()
    {
        if (!startPLaying)
        {
            if (Input.anyKeyDown)
            {
                // startPLaying = true;
                theBS.hasStarted = true;
            }
            else if (!theMusic.isPlaying)
            {
                resultsScreen.SetActive(true);
                // goodsText.text = " " + goodHits;
                // greatsText.text = " " + greatHits;
                // perfectsText.text = " " + perfectHits;
                // missesText.text = " " + missedHits;
                // moneyText.text = " " + InfoStorage.totalNotes;

                // float totalHit = goodHits + greatHits + perfectHits;
                // float percentHit = (totalHit / totalHits) * 100f;

                
                // percentHitText.text = percentHit.ToString("F1");
                {
                    Debug.Log("oops");
                }
            }
        }
    }




    public void NoteHit()
                {
                    Debug.Log("Hit on Time");

                    if (currentMultiplier - 1 < multiplierThresholds.Length)
                    {
                        multiplierTracker++;

                        if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
                        {
                            multiplierTracker = 0;
                            currentMultiplier++;
                        }
                    }


                    scoreText.text = "Score: " + currentScore;
                    multiplierText.text = "Multiplier: " + currentMultiplier;
                }

                public void NormalHit()
                {
                    currentScore += ScorePerNote;

                    NoteHit();
                    InfoStorage.totalNotes++;
                    goodHits++;
                }

                public void GoodHit()
                {
                    currentScore += ScorePerGoodNote;
                    NoteHit();
                    greatHits++;
                    InfoStorage.totalNotes++;

                }

                public void PerfectHit()
                {
                    currentScore += ScorePerPerfectNote;
                    InfoStorage.totalNotes++;
                    NoteHit();
                    perfectHits++;
                }

                public void NoteMissed()
                {
                    Debug.Log("Missed");

                    missedHits++;
                    currentMultiplier = 1;
                    multiplierText.text = "Multiplier: " + currentMultiplier;
                }

}