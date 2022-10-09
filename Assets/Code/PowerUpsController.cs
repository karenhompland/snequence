using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsController : MonoBehaviour
{
    public int ExtraTime=10;
    public int PowerUpDuration=20;

    public GameObject SequenceObject;
    private SequenceController sequenceController;

    public GameObject SnakeObject;
    private SnakeController snakeController;

    public GameObject ScoreObject;
    private ScoreController scoreController;

    private int slowerTimer=0;
    private int fasterTimer=0;
    private int starTimer=0;
    private int doublePointsTimer=0;

    private bool slowerHasReset=true;
    private bool fasterHasReset=true;
    private bool starHasReset=true;
    private bool doublePointsHasReset=true;


    // Start is called before the first frame update
    void Start()
    {
        sequenceController=SequenceObject.GetComponent<SequenceController>();
        snakeController=SnakeObject.GetComponent<SnakeController>();
        scoreController=ScoreObject.GetComponent<ScoreController>();
        
    }

    //TODO: show timer for all powerups

    // Update is called once per frame
    void Update()
    {
        if (slowerTimer>0){
            slowerTimer--;
        }
        else if (slowerTimer<=0 && !slowerHasReset){
            snakeController.ResetSpeed();
            slowerHasReset=true;
            slowerTimer=0;
        }
        if (fasterTimer>0){
            fasterTimer--;
        }
        else if (fasterTimer<=0 && !fasterHasReset){
            snakeController.ResetSpeed();
            fasterHasReset=true;
            fasterTimer=0;
        }
        if (starTimer>0){
            starTimer--;
        }
        else if (starTimer<=0 && !starHasReset){
            snakeController.StarModeOff();
            starHasReset=true;
            starTimer=0;
        }
        if (doublePointsTimer>0){
            doublePointsTimer--;
        }
        else if (doublePointsTimer<=0 && !doublePointsHasReset){
            scoreController.ResetDoubleScore();
            doublePointsHasReset=true;
            doublePointsTimer=0;
        }
        
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "ExtraTime") {
            Destroy(other.gameObject);
            sequenceController.AddTime(ExtraTime);
        }
        if (other.tag == "Slower"){
            Destroy(other.gameObject);
            snakeController.SlowerSnake();
            slowerTimer+=PowerUpDuration;
            slowerHasReset=false;
        }
        if (other.tag == "Faster") {
            Destroy(other.gameObject);
            snakeController.FasterSnake();
            fasterTimer+=PowerUpDuration;
            fasterHasReset=false;
        }
        if (other.tag == "Heart") {
            Destroy(other.gameObject);
            snakeController.ExtraLife();
        }
        if (other.tag == "Star") {
            Destroy(other.gameObject);
            snakeController.StarModeOn();
            starTimer+=PowerUpDuration;
            starHasReset=false;
        }
        if (other.tag == "DoublePoints") {
            Destroy(other.gameObject);
            scoreController.DoubleScore();
            doublePointsTimer+=PowerUpDuration;
            doublePointsHasReset=false;
        }
    }
}

