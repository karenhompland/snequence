using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public float MoveSpeed = 5;
    public float SteerSpeed = 180;
    public int Gap = 8;
    public int initialSize = 2;
    private float currentSpeed;
    private int extraLives = 0;

    public GameObject BodyPrefab;
    public GameObject SnakeTail;

    private List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PositionHistory = new List<Vector3>();

    public GameObject ScoreObject;
    private ScoreController scoreController;

    public GameObject SequenceObject;
    private SequenceController sequenceController;

    private bool BodyTimeOut=false;
    private int BodyTimeOutCounter;
   
    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = MoveSpeed;
        scoreController=ScoreObject.GetComponent<ScoreController>();
        sequenceController=SequenceObject.GetComponent<SequenceController>();
        ResetState();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * currentSpeed * Time.deltaTime;

        PositionHistory.Insert(0,transform.position);



        float steerDirection = Input.GetAxis("Horizontal");

        if (transform.rotation.eulerAngles.y == 0){
            if (Input.GetKeyDown(KeyCode.DownArrow)) {
                transform.eulerAngles = new Vector3(0,270,0);

            }
            else if (Input.GetKeyDown(KeyCode.UpArrow)) {
                 transform.eulerAngles = new Vector3(0,90,0);

            }

        }

        if (transform.rotation.eulerAngles.y == 180){
            if (Input.GetKeyDown(KeyCode.DownArrow)) {
                transform.eulerAngles = new Vector3(0,270,0);

            }
            else if (Input.GetKeyDown(KeyCode.UpArrow)) {
                 transform.eulerAngles = new Vector3(0,90,0);

            }

        }

        if (transform.rotation.eulerAngles.y == 90){
            if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                transform.eulerAngles = new Vector3(0,0,0);

            }
            else if (Input.GetKeyDown(KeyCode.RightArrow)) {
                 transform.eulerAngles = new Vector3(0,180,0);

            }

        }

        if (transform.rotation.eulerAngles.y == 270){
            if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                transform.eulerAngles = new Vector3(0,0,0);

            }
            else if (Input.GetKeyDown(KeyCode.RightArrow)) {
                 transform.eulerAngles = new Vector3(0,180,0);

            }

        }

        int index = 0;
        foreach (var body in BodyParts)
        {
            Vector3 point = PositionHistory[Mathf.Min(index*Gap, PositionHistory.Count-1)];
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * currentSpeed * Time.deltaTime;
            body.transform.LookAt(point); //point
            body.transform.Rotate(new Vector3(180,0,0));
            index++;
        }
        if (BodyTimeOut) {
            ControlBodyTimeOut();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Food") {
            Material material = other.GetComponent<MeshRenderer>().material;
            GrowSnake(material);
            if (material.name == sequenceController.GetNextSequenceObjectColor().name){
                sequenceController.SetProgress();
            }
            else{
                sequenceController.ResetProgress();
            }
            scoreController.UpdateScore(10);
        }
        if (other.tag == "Obstacle"){
            Debug.Log("Obstacle reset");
            ResetState();
        }
        if (other.tag == "Body" && !BodyTimeOut){
            Debug.Log("Body reset");
            ResetState();
        }
        if (other.tag == "Bomb") {
            if(extraLives==0){
                ResetState();
            }
            else {
                extraLives--;
            }
            Destroy(other.gameObject);
        }
    }

    private void GrowSnake(Material color) {
        BodyTimeOut=true;
        BodyTimeOutCounter=25;
        GameObject body = Instantiate(BodyPrefab);
        body.GetComponent<MeshRenderer>().material = color;
        BodyParts.Insert(BodyParts.Count-1,body);
    }

    private void ControlBodyTimeOut() {
        BodyTimeOutCounter--;
        if (BodyTimeOutCounter==0){
            BodyTimeOut=false;
        }

    }

    private void AddTail(){
        GameObject tail = Instantiate(SnakeTail);
        tail.transform.localScale = new Vector3(40,40,40);
        BodyParts.Add(tail);
    }

    private void ResetState(){
        //scoreController.Start();
        for (int i = 0 ; i < BodyParts.Count ; i++) {
            Destroy(BodyParts[i].gameObject);
        }
        BodyParts.Clear();
        
        AddTail();

        for (int i = 0 ; i < initialSize ; i++) {
            //GrowSnake(SeeThroughMaterial);
        }

        this.transform.position = Vector3.zero;
    }

    public void FasterSnake(){
        currentSpeed = currentSpeed*1.5f;
    }

    public void SlowerSnake(){
        currentSpeed = currentSpeed*0.5f;
    }

    public void ResetSpeed() {
        currentSpeed=MoveSpeed;
    }

    public void ExtraLife() {
        extraLives+=1;
        //TODO vise antall hjerter på skjermen
    }

    public void StarModeOn(){

    }

    public void StarModeOff(){

    }
}
