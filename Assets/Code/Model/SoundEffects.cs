using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource Eat;
    public AudioSource AddHeart;
    public AudioSource RemoveHeart;
    public AudioSource SequenzeComplete;
    public AudioSource Loose;
    public AudioSource WrongColor;
    public AudioSource PowerUp;
    public AudioSource GameOver;
    public AudioSource TimeRunningOut;
    public AudioSource Bomb;

    public void PlayBomb(){
        Bomb.Play();
    }

    public void PlayTimeRunningOut(){
        TimeRunningOut.Play();
    }

    public void PlaySequenzeComplete(){
        SequenzeComplete.Play();
    }

    public void PlayGameOver(){
        GameOver.Play();
    }

    public void PlayPowerUp(){
        PowerUp.Play();
    }

    public void PlayWrongColor(){
        WrongColor.Play();
    }

    public void PlayLoose(){
        Loose.Play();
    }

    public void PlayEat(){
        Eat.Play();
    }

    public void PlayAddHeart(){
        AddHeart.Play();
    }

    public void PlayRemoveHeart(){
        RemoveHeart.Play();
    }
    
}
