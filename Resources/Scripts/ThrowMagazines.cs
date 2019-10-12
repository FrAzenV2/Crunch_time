using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ThrowMagazines : MonoBehaviour
{
    public Image[] magazines = new Image[3];
    public int numberOFAvaliableMagaz = 0;//0 = 1
    public static int nextID = 0;
    Color co;
    public GameObject prefab;

    public void hideMagaz()
    {
        int i = 2 - numberOFAvaliableMagaz;
        for(int p=2; p>i; p--)
        {
            co = magazines[p].GetComponent<Image>().color;
            co.a = 0.0f;
            magazines[p].GetComponent<Image>().color = co;
        }
    }

    public void restMagaz()
    {
        int i = 2 - numberOFAvaliableMagaz;
        for (int p = 2; p > i; p--)
        {
            co = magazines[p].GetComponent<Image>().color;
            co.a = 1.0f;
            magazines[p].GetComponent<Image>().color = co;
        }
    }


    void throwMagaz(bool right)
    {
        int r = Random.Range(0, 1);
        if(right) magazines[nextID].GetComponent<Animation>().Play("ThrowR");
        else magazines[nextID].GetComponent<Animation>().Play("ThrowL");
        nextID++;

        if (nextID > numberOFAvaliableMagaz)
        {
            Instantiate(prefab);
            Destroy(this);
            //fin throwing stage
        }
    }
}
