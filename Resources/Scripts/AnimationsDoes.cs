using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AnimationsDoes : MonoBehaviour
{
    // Start is called before the first frame update
    Sequence mySequence;
    public bool inAnimation = false;

    void inAnimationChange()
    {
        inAnimation = !inAnimation;
    }
    public void animateUp()
    {
        mySequence = DOTween.Sequence();
        inAnimationChange();
        Invoke("inAnimationChange", 1);

        
        float y = this.transform.position.y;
        mySequence.Append(this.transform.DOMoveY(+10f, 1f));

    }

    public void animateDown(int time)
    {

        mySequence = DOTween.Sequence();
        inAnimationChange();
        Invoke("inAnimationChange", 2);

        float y = this.transform.position.y;
        mySequence.Append(this.transform.DOMoveY(-10f, 1f));

        StartCoroutine(wait(time));


        mySequence = DOTween.Sequence();
        inAnimationChange();
        Invoke("inAnimationChange", 5);

        y = this.transform.position.y;
        mySequence.Append(this.transform.DOMoveY(0f, 5f));

    }

    IEnumerator wait(int time)
    {
        yield return new WaitForSeconds(time);
    }

    public void animateDown()
    {
        mySequence = DOTween.Sequence();
        inAnimationChange();
        Invoke("inAnimationChange", 1);


        float y = this.transform.position.y;
        mySequence.Append(this.transform.DOMoveY(0f, 1f));

    }
    public void animateRight()
    {
        mySequence = DOTween.Sequence();
        inAnimationChange();
        Invoke("inAnimationChange", 1);


        float x = this.transform.position.x;
        mySequence.Append(this.transform.DOMoveX(-10f, 1f));

    }

    public void animateLeft()
    {
        mySequence = DOTween.Sequence();
        inAnimationChange();
        Invoke("inAnimationChange", 1);


        float x = this.transform.position.x;
        mySequence.Append(this.transform.DOMoveX(10f, 1f));

    }
}
