using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private Vector2 startTouchPos; // start pos of swipe
    private Vector2 endTouchPos; //end pos of swipe
    Vector2 swipe; // the current swipe
    
    // Called on every frame, detects true swipe.
    public string OnSwipe() 
    {
        // check if it is a "true" touch
        if(Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if(t.phase == TouchPhase.Began)
            {
                // beginning of touch pt (2D)
                startTouchPos = new Vector2(t.position.x,t.position.y);
            }
            if(t.phase == TouchPhase.Ended)
            {
                // end of touch point
                endTouchPos= new Vector2(t.position.x,t.position.y);
                            
                // new vector for the swipe
                swipe = new Vector3(endTouchPos.x - startTouchPos.x, endTouchPos.y - startTouchPos.y);
                
                //normalize the 2d vector (fixes bug with swiping in multiple dimensions.)
                swipe.Normalize();
    
                //swipe upwards
                if(swipe.y > 0&&swipe.x > -0.5f&&swipe.x < 0.5f)
                {
                    Debug.Log("up swipe");
                    return "up";
                }
                //swipe down
                if(swipe.y < 0&&swipe.x > -0.5f&&swipe.x < 0.5f)
                {
                    Debug.Log("down swipe");
                    return "down";
                }
                //swipe left
                if(swipe.x < 0&&swipe.y > -0.5f&&swipe.y < 0.5f)
                {
                    Debug.Log("left swipe");
                    return "left";
                }
                //swipe right
                if(swipe.x > 0 &&swipe.y > -0.5f &&swipe.y < 0.5f)
                {
                    Debug.Log("right swipe");
                    return "right";
                }

            }
        }
            return "";
        
        }   

     
}
