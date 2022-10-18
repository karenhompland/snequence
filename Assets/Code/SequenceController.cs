using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class SequenceController : MonoBehaviour
{
    public GameObject OrangeBall;
    public GameObject YellowBall;
    public GameObject PinkBall;
    public GameObject PurpleBall;
    public GameObject BlueBall;

    public Material Orange;
    public Material Yellow;
    public Material Pink;
    public Material Purple;
    public Material Blue;
    public Material Grey;

    public GameObject ScoreObject;
    private ScoreController scoreController;

    public GameObject SoundEffects;
    private SoundEffects soundEffectsController;

    public GameObject GameOverController;
    private GameOverController gameOverController;

    public GameObject SnakeObject;
    private SnakeController snakeController;

    public int SequenceLength = 3;

    public int SetDuration;
    private int RemainingDuration;
    private int Duration;
    private int progress;

    private List<int> Sequence = new List<int>();
    private List<GameObject> SequenceObjects = new List<GameObject>();

    private static System.Random Rnd = new System.Random();
    [SerializeField] private Image uiFill;
    [SerializeField] private TMP_Text uiText;

    // Start is called before the first frame update
    void Start()
    {
        progress=0;
        scoreController=ScoreObject.GetComponent<ScoreController>();
        soundEffectsController=SoundEffects.GetComponent<SoundEffects>();
        gameOverController = GameOverController.GetComponent<GameOverController>();
        snakeController=SnakeObject.GetComponent<SnakeController>();
        Duration=SetDuration;
        Being(Duration);
        NewSequence();
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    public int GetNextSequenceObjectIndex(){
        return this.Sequence[progress];
    }

    public Material GetNextSequenceObjectColor(){
        return this.SequenceObjects[progress].GetComponent<MeshRenderer>().material;
    }

    public void SetProgress(){
        SequenceObjects[progress].GetComponent<MeshRenderer>().material=Grey;
        if (progress==Sequence.Count-1){
            FinishedSequence();
            progress=0;
        }
        else {
            progress++;
        }
    }

    public void ResetProgress() {
        if(progress!=0){
            for (int i=0; i<Sequence.Count ; i++){
                if(Sequence[i]==0){
                    SequenceObjects[i].GetComponent<MeshRenderer>().material=Orange;
                }
                else if(Sequence[i]==1){
                    SequenceObjects[i].GetComponent<MeshRenderer>().material=Yellow;       
                }
                else if(Sequence[i]==2){
                    SequenceObjects[i].GetComponent<MeshRenderer>().material=Pink;           
                }
                else if(Sequence[i]==3){
                    SequenceObjects[i].GetComponent<MeshRenderer>().material=Purple;                
                }
                else if(Sequence[i]==4){
                    SequenceObjects[i].GetComponent<MeshRenderer>().material=Blue;              
                }
            }
        }
        progress=0;

        
    }

    private void NewSequence() {
        foreach (var sequenceColorBall in SequenceObjects){
            Destroy(sequenceColorBall);
        }
        Sequence.Clear();
        SequenceObjects.Clear();
        for (int i=0 ; i<SequenceLength ; i++) {
            int nextBall = Rnd.Next(0, 5);
            Sequence.Add(nextBall);
            GameObject ball = new GameObject();  
            if(nextBall==0){
                 ball = Instantiate(OrangeBall);
            }
            else if(nextBall==1){
                 ball = Instantiate(YellowBall);            
            }
            else if(nextBall==2){
                 ball = Instantiate(PinkBall);                
            }
            else if(nextBall==3){
                 ball = Instantiate(PurpleBall);                
            }
            else if(nextBall==4){
                 ball = Instantiate(BlueBall);                 
            }
            int gap = 4 -i*2;
            ball.transform.localScale+= new Vector3(50,50,50);
            ball.transform.position= new Vector3(12,0,gap);
            SequenceObjects.Add(ball);
        }
    }

    private void Being(int Second) {
        RemainingDuration = Second;
        StartCoroutine(UpdateTimer());
    }

    public void AddTime(int Seconds) {
        Duration+=Seconds;
        RemainingDuration+=Seconds;
        if (RemainingDuration > 3) {
            uiFill.color=new Color(0.04023647f, 1f, 0f, 1f);
        }
    }

    private IEnumerator UpdateTimer() {
        while(RemainingDuration >= 0){
            if (RemainingDuration == 3) {
                soundEffectsController.PlayTimeRunningOut();
                uiFill.color=new Color(1f, 0.2235294f, 0f, 1f);
            }
            uiText.text = $"{RemainingDuration}";
            uiFill.fillAmount = Mathf.InverseLerp(0,Duration,RemainingDuration);
            RemainingDuration--;
            yield return new WaitForSeconds(1f);
        }
        OnTimeEnd();

    }

    private void OnTimeEnd(){
        gameOverController.GameOver();
    }

    private void FinishedSequence(){
        scoreController.UpdateScore(100);
        NewSequence();
        soundEffectsController.PlaySequenzeComplete();
        AddTime(SetDuration);
        snakeController.NextLevel();
    }

    
}
