using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Card_Rotater : MonoBehaviour
{

    public GameObject backSide;
    public GameObject frontSide;


    Sequence mySequence; 

    public void TurnCard(int which_seq)
    {

        if (DOTween.PlayingTweens().Count == 0)
        if (which_seq == 1)
        {
            mySequence = DOTween.Sequence();
            //first seq
            // Add a movement tween at the beginning
            mySequence.Append(frontSide.transform.DORotate(new Vector3(0, 90, 0), 0.5f));
            // Add a rotation tween as soon as the previous one is finished
            mySequence.Append(backSide.transform.DORotate(new Vector3(0, 90, 0), 0.5f, RotateMode.WorldAxisAdd));
        }
        else if (which_seq == 2)
        {
            mySequence = DOTween.Sequence();

            mySequence.Append(backSide.transform.DORotate(new Vector3(0, -90, 0), 0.5f));
            mySequence.Append(frontSide.transform.DORotate(new Vector3(0, 0, 0), 0.5f));
            mySequence.Append(frontSide.transform.DORotate(new Vector3(0, 90, 0), 0.5f));
            // Add a rotation tween as soon as the previous one is finished
            mySequence.Append(backSide.transform.DORotate(new Vector3(0, 90, 0), 0.5f, RotateMode.WorldAxisAdd));

        }
        else if( which_seq == 0)
        {

        }
    }
}
