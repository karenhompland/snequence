using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiateBoard : MonoBehaviour
{
    public BoxCollider gridArea;
    public GameObject foodPrefab;

    public GameObject Star;
    public GameObject Heart;
    public GameObject DoubleScore;
    public GameObject Time;
    public GameObject Faster;
    public GameObject Slower;

    public GameObject Bomb;

    public Material PinkMaterial;
    public Material OrangeMaterial;
    public Material BlueMaterial;
    public Material PurpleMaterial;
    public Material YellowMaterial;

    public int initialFood = 10;
    public int initialPowerUps = 0;
    public int initialBomb = 0;
    public int foodInterval = 3;
    public int powerUpsInterval = 30;
    public int bombInterval = 45;

    private List<Material> Materials = new List<Material>();
    private List<GameObject> PowerUps = new List<GameObject>();
    private List<Vector3> ObjectsOnBoard = new List<Vector3>();


    public GameObject SequenceObject;
    private SequenceController sequenceController;

    private static System.Random Rnd = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        sequenceController=SequenceObject.GetComponent<SequenceController>();
        
        Materials.Add(OrangeMaterial);
        Materials.Add(YellowMaterial);
        Materials.Add(PinkMaterial);
        Materials.Add(PurpleMaterial);
        Materials.Add(BlueMaterial);
        

        PowerUps.Add(Star);
        PowerUps.Add(Heart);
        PowerUps.Add(DoubleScore);
        PowerUps.Add(Time);
        PowerUps.Add(Faster);
        PowerUps.Add(Slower);

        initaiteFood();
        //initiatePowerUps();
        //initiateBombs();

        InvokeRepeating ("newFood", 1, foodInterval);
        InvokeRepeating ("newPowerUp", 5, powerUpsInterval);
        InvokeRepeating ("newBomb", 20, bombInterval);

    }

    private void initaiteFood(){
        for (int i = 0; i < initialFood; i++) {
            newFood();
       }
    }

    private void initiatePowerUps() {
        for (int i = 0; i < initialPowerUps; i++) {
            newPowerUp();
       }
    }

    private void initiateBombs(){
        for (int i = 0; i < initialBomb; i++) {
            newBomb();

       }

    }

    private Vector3 getRandomVector(){
        Bounds bounds = this.gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float z = Random.Range(bounds.min.z, bounds.max.z);
        Vector3 position = new Vector3(Mathf.Round(x), 0.0f, Mathf.Round(z));
        return position;
     }

    private Vector3 placeObject() {
        return getRandomVector();
        
        // Bounds bounds = this.gridArea.bounds;
        // float x = Random.Range(bounds.min.x, bounds.max.x);
        // float z = Random.Range(bounds.min.z, bounds.max.z);
        // Vector3 position = new Vector3(Mathf.Round(x), 0.0f, Mathf.Round(z));
        // bool positionFound = false;
        // bool positionOk = true;
        // int allowedDist = 5;
        // Vector3 vector = new Vector3(0,0,0);
        // // Vector3 position = getRandomVector();

        // while (positionFound == false){
        //     Vector3 position = getRandomVector();
        //     foreach(GameObject obj in this.ObjectsOnBoard) {
        //         float dist = Vector3.Distance(position, obj.transform.position);
        //         Debug.Log(dist);
        //         if (dist < allowedDist) {
        //             positionOk = false;
        //             break;
        //         }
        //     }
        //     if (positionOk == true) {
        //         positionFound = true;
        //         vector = position;
        //     }
        // }
        
        // return vector;

        

        // var sphereRadius = 10;
       
        // if (Physics.CheckSphere(position, sphereRadius)){
        //     Debug.Log("collide");
        //     position = getRandomVector();
        // }
          
        // return position;

        // GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        // bool distOk = true;
        // int minDistanceGameObject = 5;
        // foreach(GameObject obj in allObjects){
        //     float dist = Vector3.Distance(position, obj.transform.position);
        //     Debug.Log(dist);
        //     if (dist < minDistanceGameObject) {
        //         distOk = false;   
        //     } 
        // }
        // if (distOk) {
        //     return position;
        // }
        // else {
        //     return placeObject();
        // }
        
    }

    private void newFood() {
        Vector3 position = placeObject();
        GameObject food = Instantiate(foodPrefab);
        int MaterialIndex;
        int random = Rnd.Next(0,2);
        if (random == 0) {
            MaterialIndex = sequenceController.GetNextSequenceObjectIndex();
        }
        else{ 
            MaterialIndex = Rnd.Next(0,Materials.Count); 
        }

        food.GetComponent<MeshRenderer> ().material = Materials[MaterialIndex];
        food.transform.position = position;
        ObjectsOnBoard.Add(food.transform.position);
    }

    private void newBomb(){
        Vector3 position = placeObject();
        GameObject bomb = Instantiate(Bomb);
        bomb.transform.Rotate(0,0,-40);
        bomb.transform.position = position;
        ObjectsOnBoard.Add(bomb.transform.position);
    }

    private void newPowerUp(){
        Vector3 position = placeObject();
        GameObject powerUp = Instantiate(PowerUps[Rnd.Next(0, PowerUps.Count)]);
        powerUp.transform.position = position;
        ObjectsOnBoard.Add(powerUp.transform.position);
     }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void removeGameObject(Vector3 position) {
        ObjectsOnBoard.Remove(position);
    }
}