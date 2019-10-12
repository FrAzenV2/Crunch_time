using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class InkManager : MonoBehaviour
{
    // UI Prefabs
    [SerializeField]
    private Text variant1;
    [SerializeField]
    private Text variant2;
    
    public Text storyText;

    public Card_Rotater card_Rotater;

    [SerializeField]
    private TextAsset inkJSONAsset;

    public Story story;

    [SerializeField]
    private Canvas canvas;

    public bool storyEnded = false;
    private bool firstTime = true;
    

    public Choice choice0;
    public Choice choice1;

    CharacterManager cm;
    Game_Manager gm;

    void Start()
    {
        //cm = GetComponent<CharacterManager>();
        //gm = GetComponent<Game_Manager>(); 
        // Remove the default message
        //RemoveChildren();
        //Debug.Log("!@@!@!");
        StartStory();
        //RefreshView();
    }

    void StartStory()
    {
        storyEnded = false;
        firstTime = true;
        story = new Story(inkJSONAsset.text);
        //Debug.Log("!@@!@!");
        RefreshView();
    }
    void RefreshView()
    {


        // Read all the content until we can't continue any more
        while (story.canContinue)
        {
            // Continue gets the next line of the story
            string text = story.Continue();
            // This removes any white space from the text.
            text = text.Trim();
            // Display the text on screen!
            storyText.text = text;
        }
        if (firstTime)
        {
            firstTime = !firstTime;
            card_Rotater.TurnCard(1);
        }

        //Debug.Log("!@!@!@!");
        // Display all the choices, if there are any!
        if (story.currentChoices.Count > 0)
        {
            //Debug.Log("!@@@!");
            Debug.Log(story.currentChoices.Count);
            choice0 = story.currentChoices[0];
            choice1 = story.currentChoices[1];

            variant1.text = choice0.text.Trim();
            variant2.text = choice1.text.Trim();
            
            //ChoiseSelecter();
        }
        // If we've read all the content and there's no choices, the story is finished!
        else
        {
            storyEnded = true;
            variant1.text = "End of the day";
            variant2.text = "End of the day";
        }
        //Debug.Log("!@@!!@!");
        
    }


    public void ChooseLeft()
    {
      if (!card_Rotater.inAnimation)
        if (storyEnded)
        {
            StartStory();
        }
        else
        {
       
            card_Rotater.TurnCard(2);
            //story.ChooseChoiceIndex(choice0.index);
            StartCoroutine(Delay(0));
            //RefreshView();
        }
    }

    public void ChooseRight()
    {
       if(!card_Rotater.inAnimation) 
        if (storyEnded)
        {

            StartStory();
        }
        else
        {
            
            card_Rotater.TurnCard(2);
            StartCoroutine(Delay(1));

            //story.ChooseChoiceIndex(choice1.index);
            
        }
    }

   /* void ChoiseSelecter()
    {
        if (Input.GetMouseButtonDown(0) && !inAnimation)
        {
            if (Swipe_detector.directionX == -1)
            {
                story.ChooseChoiceIndex(choice0.index);
            }
            else if (Swipe_detector.directionX == 1)
            {
                story.ChooseChoiceIndex(choice1.index);
            }
            //Debug.Log("!@!!!@@!");
            Swipe_detector.Reset_SwipeX();
            RefreshView();
        }
    }*/

    IEnumerator Delay(int id)
    {
        yield return new WaitForSeconds(0.3f);
        if (id == 1)
        {
            story.ChooseChoiceIndex(choice1.index);
            yield return new WaitForSeconds(0.2f);
            
        }
        else if (id == 0)
        {
            story.ChooseChoiceIndex(choice0.index);
            yield return new WaitForSeconds(0.2f);
         
            
        }
        
        RefreshView();
    }
    
}
