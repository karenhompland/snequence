using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{

    public GameObject SoundEffects;
    private SoundEffects soundEffectsController;

    void Start(){
        soundEffectsController=SoundEffects.GetComponent<SoundEffects>();
    }

    public void GameOver(){
        SceneManager.LoadScene(3);
        soundEffectsController.PlayGameOver();
    }





}
