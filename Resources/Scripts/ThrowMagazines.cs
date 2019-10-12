using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class ThrowMagazines : MonoBehaviour
{
    public GameObject[] magazines = new GameObject[3];
    public int numberOFAvaliableMagaz = 0;//0 = 1
    public static int nextID = 0;
    Color co;
    public GameObject mainCam;
    public static bool can = false;

    public bool inAnimation;

    public void hideMagaz()
    {
        for(int p = numberOFAvaliableMagaz+1; p<3; p++)
        {
            co = magazines[p].GetComponent<Image>().color;
            co.a = 0.0f;
            magazines[p].GetComponent<Image>().color = co;
        }
    }

    public void restMagaz()
    {
        for (int p = numberOFAvaliableMagaz+1; p < 3; p++)
        {
            co = magazines[p].GetComponent<Image>().color;
            co.a = 1.0f;
            magazines[p].GetComponent<Image>().color = co;
        }
    }

    void inAnimationChange()
    {
        inAnimation = !inAnimation;
    }
    public void throwMagaz()
    {
        if(can)
        {
            Sequence mySequence = DOTween.Sequence();
            inAnimationChange();
            Invoke("inAnimationChange", 2);
            mySequence.Append(magazines[nextID].transform.DORotate(new Vector3(0, -90, 0), 0.5f));

            nextID++;

            if (nextID > numberOFAvaliableMagaz)
            {
                nextID = 0;

                Invoke("inAnimationChange", 2);

                mySequence.Append(this.transform.DOMoveY(-10f, 2f));

                for (int i = 0; i <= numberOFAvaliableMagaz; i++)
                {
                    // mySequence = DOTween.Sequence();
                    inAnimationChange();
                    Invoke("inAnimationChange", 2);
                    mySequence.Append(magazines[i].transform.DORotate(new Vector3(0, 0, 0), 0.5f));
                }
                mainCam.GetComponent<Swipe_detector>().hideMagazine();

                can = false;
                StartCoroutine(wait4(2));
                //fin throwing stage
            }
        }
    }

    IEnumerator wait4(int time)
    {
        yield return new WaitForSeconds(time);
        restMagaz();
    }
}
