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
    public int minDistanceGameObject = 5;

    private List<Material> Materials = new List<Material>();
    private List<GameObject> PowerUps = new List<GameObject>();

    private static System.Random Rnd = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        Materials.Add(PinkMaterial);
        Materials.Add(OrangeMaterial);
        Materials.Add(BlueMaterial);
        Materials.Add(PurpleMaterial);
        Materials.Add(YellowMaterial);

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

    private Vector3 placeObject() {
        Bounds bounds = this.gridArea.bounds;
        bool distOk = true;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float z = Random.Range(bounds.min.z, bounds.max.z);

        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach(GameObject obj in allObjects){
            float dist = Vector3.Distance(new Vector3(Mathf.Round(x),0.0f, Mathf.Round(z)), obj.transform.position);
            if (dist < minDistanceGameObject) {
                distOk = false;   
            } 
        }

        if (!distOk) {
            placeObject();
        }
        return new Vector3(Mathf.Round(x),0.0f, Mathf.Round(z)); 
    }

    private void newFood() {
        Vector3 position = placeObject();
        GameObject food = Instantiate(foodPrefab);
        int color = Rnd.Next(0, Materials.Count);

        food.GetComponent<MeshRenderer> ().material = Materials[color];
        food.transform.position = position; 
    }

    private void newBomb(){
        Vector3 position = placeObject();
        GameObject bomb = Instantiate(Bomb);
        bomb.transform.position = position;

    }

    private void newPowerUp(){
        Vector3 position = placeObject();
        GameObject powerUp = Instantiate(PowerUps[Rnd.Next(0, PowerUps.Count)]);
        powerUp.transform.position = position;
     }

    // Update is called once per frame
    void Update()
    {
        
    }
}