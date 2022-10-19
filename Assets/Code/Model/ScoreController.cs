using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreController : MonoBehaviour
{
    public GameObject Symbol;
    [SerializeField] private TMP_Text ScoreText;
    private int Score;
    private bool doubleScore;
    private GameObject symbol;
    void Start()
    {
        doubleScore=false;
        Score=0;
        ScoreText.text=$"{Score}";
        symbol = Instantiate(Symbol);
        symbol.transform.position = new Vector3(11.8f,-4f,-19.1f);
        symbol.transform.localScale+= new Vector3(0.7f,0.7f,0.7f);
        
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


    public void DoubleScore(){
        doubleScore=true;
        symbol.transform.position = new Vector3(11.8f,0f,-19.1f);
    }
    public void ResetDoubleScore(){
        symbol.transform.position = new Vector3(11.8f,-4f,-19.1f);
        doubleScore=false;
    }
}
