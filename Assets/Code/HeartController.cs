using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour
{
    public GameObject Heart;
    public Material GrayMaterial;
    public Material PinkMaterial;
   
    private int hearts = 0;
    private List<GameObject> HeartsList = new List<GameObject>();
 


    public void addHeart() {
        hearts ++;
        HeartsList[hearts-1].GetComponent<MeshRenderer> ().material = PinkMaterial;
    }

    public void removeHeart() {
        hearts --;
        HeartsList[hearts].GetComponent<MeshRenderer> ().material = GrayMaterial;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i<3 ; i++) {
            GameObject heart = new GameObject();  
            int gap = 8 - i*3;
            heart = Instantiate(Heart);
            heart.GetComponent<MeshRenderer> ().material = GrayMaterial;
            heart.transform.position= new Vector3(12,0,gap);
            HeartsList.Add(heart);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
