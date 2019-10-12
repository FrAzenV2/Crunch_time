using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swipe_detector : MonoBehaviour
{
    void Update()
    {
        Swipe();
    }

    public InkManager inkManager;
    public Canvas settingMenu;
    public Canvas magazine;
    public Image fadeIm;

    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    public static float directionX = 0; //  left = -1 , right = 1, stay = 0;
    public static float dirY = 0; // 0 - stay, 1 - downed

    public static bool showMenu = true;
    public static bool fade = true;
    public static bool notMenu = true;
    public static bool notEnd = true;

    public void reset()
    {
        bool showMenu = true;
        bool fade = true;
        bool notMenu = true;
        bool notEnd = true;
    }   
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
                if (currentSwipe.y < -0.5f && notEnd)
                {
                    Debug.Log("down swipe");
                    notMenu = false;
                    dirY = 1;
                    showSettMenu();
                }
                //swipe left
                else if (currentSwipe.x < -0.5f && notMenu && notEnd)
                {
                    Debug.Log("left swipe");
                    directionX = -1;
                    inkManager.ChooseLeft();
                }
                //swipe right
                else if (currentSwipe.x > 0.5f && notMenu && notEnd)
                {
                    Debug.Log("right swipe");
                    directionX = 1;
                    inkManager.ChooseRight();
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            //save began touch 2d point
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(1) && notMenu)
        {
            showMagazine();
        }
        if (Input.GetMouseButtonUp(0))
        {
            //save ended touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            //create vector from the two points
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

            //normalize the 2d vector
            currentSwipe.Normalize();


            if (currentSwipe.y < -0.5f && notEnd)
            {
                Debug.Log("down swipe");
                notMenu = false;
                dirY = 1;
                showSettMenu();
            }
            //swipe left
            else if (currentSwipe.x < -0.5f && notMenu && notEnd)
            {
                Debug.Log("left swipe");
                directionX = -1;
                inkManager.ChooseLeft();
            }
            //swipe right
            else if (currentSwipe.x > 0.5f && notMenu && notEnd)
            {
                Debug.Log("right swipe");
                directionX = 1;
                inkManager.ChooseRight();
            }
        }


    }

    public void showMagazine()
    {
        //Animation to show
        if (fade)
        {
            fadeIm.GetComponent<Animation>().Play("FadeAnim");
            magazine.GetComponent<ThrowMagazines>().hideMagaz();
            magazine.GetComponent<AnimationsDoes>().animateDown(4);

            //MOOORE ANIMATIONS
            notEnd = false;
            fade = false;
            StartCoroutine(wait(4));
        }
    }

    public void hideMagazine()
    {
        //Animation to hide
            fadeIm.GetComponent<Animation>().Play("NOTFadeAnim");
        StartCoroutine(wait4(2));
    }

    public void showSettMenu()
    {
        if(showMenu)
        {
            //Animation to show
            settingMenu.GetComponent<AnimationsDoes>().animateDown();
            showMenu = false;
        }
    }

    public void hideSettMenu()
    {
        //Animation to close
        //Animation to show
        settingMenu.GetComponent<AnimationsDoes>().animateUp();

        notMenu = true;
        showMenu = true;
      
    }

    public static void Reset_SwipeX()
    {
        directionX = 0;
    }

    public static void Reset_SwipeY()
    {
        dirY = 0;
    }

    IEnumerator wait4(int time)
    {
        yield return new WaitForSeconds(time);
        notEnd = true;
        fade = true;
    }

    IEnumerator wait(int time)
    {
        yield return new WaitForSeconds(time);
        ThrowMagazines.can = true;
    }
}
