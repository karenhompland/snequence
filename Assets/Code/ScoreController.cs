using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TMP_Text ScoreText;
    private int Score;
    private bool doubleScore;
    // Start is called before the first frame update
    void Start()
    {
        doubleScore=false;
        Score=0;
        ScoreText.text=$"{Score}";
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateScore(int score){
        if (doubleScore) {
            Score+=2*score;
        }
        else {
            Score+=score;
        }
        ScoreText.text=$"{Score}";
    }

    public void GameOver(){
        //save score
        
    }

    public void DoubleScore(){
        doubleScore=true;
    }
    public void ResetDoubleScore(){
        doubleScore=false;
    }
}
