using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Card_Rotater : MonoBehaviour
{

    public GameObject backSide;
    public GameObject frontSide;

    public bool inAnimation = false;

    Sequence mySequence;

    void inAnimationChange()
    {
        inAnimation = !inAnimation;
    }
    public void TurnCard(int which_seq)
    {
        
        if (which_seq == 1)
        {
            mySequence = DOTween.Sequence();
            inAnimationChange();
            Invoke("inAnimationChange", 1);
            //first seq
            // Add a movement tween at the beginning
            mySequence.Append(frontSide.transform.DORotate(new Vector3(0, 90, 0), 0.5f));
            // Add a rotation tween as soon as the previous one is finished
           // Debug.Log(DOTween.PlayingTweens().Count + " pupa");
            mySequence.Append(backSide.transform.DORotate(new Vector3(0, 90, 0), 0.5f, RotateMode.WorldAxisAdd));
            
        }
        else if (which_seq == 2)
        {
            //mySequence = DOTween.Sequence();
            mySequence = DOTween.Sequence();
            inAnimationChange();
            Invoke("inAnimationChange", 2);
            mySequence.Append(backSide.transform.DORotate(new Vector3(0, -90, 0), 0.5f));
            mySequence.Append(frontSide.transform.DORotate(new Vector3(0, 0, 0), 0.5f));
            mySequence.Append(frontSide.transform.DORotate(new Vector3(0, 90, 0), 0.5f));
            // Add a rotation tween as soon as the previous one is finished
            //Debug.Log(DOTween.PlayingTweens().Count + " pupa");
            mySequence.Append(backSide.transform.DORotate(new Vector3(0, 90, 0), 0.5f, RotateMode.WorldAxisAdd));

        }
        else if( which_seq == 31)
        {
            mySequence = DOTween.Sequence();
            inAnimationChange();
            Invoke("inAnimationChange", 2);
            float x = backSide.transform.position.x;
            mySequence.Append(backSide.transform.DOMoveX(-200f, 0.5f));
            mySequence.Append(backSide.transform.DORotate(new Vector3(0, -90, 0), 0.5f));
            mySequence.Append(backSide.transform.DOMoveX( x,  0.1f));
            //Смена картинки рубашки
            mySequence.Append(frontSide.transform.DORotate(new Vector3(0, 0, 0), 0.5f));

        }
        else if( which_seq == 32)
        {
            mySequence = DOTween.Sequence();
            inAnimationChange();
            Invoke("inAnimationChange", 2);
            float x = backSide.transform.position.x;
            mySequence.Append(backSide.transform.DOMoveX(1500f, 0.5f));
            mySequence.Append(backSide.transform.DORotate(new Vector3(0, -90, 0), 0.5f));
            mySequence.Append(backSide.transform.DOMoveX(x, 0.1f));

            mySequence.Append(frontSide.transform.DORotate(new Vector3(0, 0, 0), 0.5f));

        }

    }
}
