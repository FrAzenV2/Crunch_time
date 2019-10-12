 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swipe_4_magazines : MonoBehaviour
{
    void Update()
    {
        Swipe();
    }

    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    public static float directionX = 0; //  left = -1 , right = 1, stay = 0;
    public static float dirY = 0; // 0 - stay, 1 - downed

    public void Swipe()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                //save began touch 2d point
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }
            if (t.phase == TouchPhase.Ended)
            {
                //save ended touch 2d point
                secondPressPos = new Vector2(t.position.x, t.position.y);

                //create vector from the two points
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                //normalize the 2d vector
                currentSwipe.Normalize();

                /*swipe upwards
                if (currentSwipe.y > 0  currentSwipe.x > -0.5f  currentSwipe.x < 0.5f)
                {
                    Debug.Log("up swipe");
                }*/
                //swipe down
             if (currentSwipe.x < -0.5f && !Swipe_detector.notEnd)
                {
                    Debug.Log("left swipe");
                    directionX = -1;
                    
                    this.GetComponent<ThrowMagazines>().throwMagaz();
                }
                //swipe right
                else if (currentSwipe.x > 0.5f && !Swipe_detector.notEnd)
                {
                    Debug.Log("right swipe");
                    directionX = 1;
                    this.GetComponent<ThrowMagazines>().throwMagaz();
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            //save began touch 2d point
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(0))
        {
            //save ended touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            //create vector from the two points
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

            //normalize the 2d vector
            currentSwipe.Normalize();


            //swipe left
            if (currentSwipe.x < -0.5f && !Swipe_detector.notEnd)
            {
                Debug.Log("left swipe");
                this.GetComponent<ThrowMagazines>().throwMagaz();
                directionX = -1;
            }
            //swipe right
            else if (currentSwipe.x > 0.5f && !Swipe_detector.notEnd)
            {
                Debug.Log("right swipe");
                this.GetComponent<ThrowMagazines>().throwMagaz();
                directionX = 1;
            }
        }


    }


    public static void Reset_SwipeX()
    {
        directionX = 0;
    }

    public static void Reset_SwipeY()
    {
        dirY = 0;
    }
}
