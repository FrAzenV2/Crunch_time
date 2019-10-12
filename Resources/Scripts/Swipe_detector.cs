using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe_detector : MonoBehaviour
{
    void Update()
    {
        Swipe();
    }

    public InkManager inkManager;

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
                if (currentSwipe.y < -0.5f)
                {
                    Debug.Log("down swipe");
                    dirY = 1;

                }
                //swipe left
                else if (currentSwipe.x < -0.5f)
                {
                    Debug.Log("left swipe");
                    directionX = -1;
                }
                //swipe right
                else if (currentSwipe.x > 0.5f)
                {
                    Debug.Log("right swipe");
                    directionX = 1;
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


            if (currentSwipe.y < -0.5f)
            {
                Debug.Log("down swipe");
                dirY = 1;

            }
            //swipe left
            else if (currentSwipe.x < -0.5f)
            {
                Debug.Log("left swipe");
                directionX = -1;
                inkManager.ChooseLeft();
            }
            //swipe right
            else if (currentSwipe.x > 0.5f)
            {
                Debug.Log("right swipe");
                directionX = 1;
                inkManager.ChooseRight();
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
