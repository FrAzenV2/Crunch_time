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

    [SerializeField]
    private TextAsset inkJSONAsset;
    public Story story;

    [SerializeField]
    private Canvas canvas;

    private Choice choice0;
    private Choice choice1;

    CharacterManager cm;
    Game_Manager gm;

    void Start()
    {
        //cm = GetComponent<CharacterManager>();
        //gm = GetComponent<Game_Manager>(); 
        // Remove the default message
        //RemoveChildren();

        StartStory();
        RefreshView();
    }

    void StartStory()
    {
        story = new Story(inkJSONAsset.text);
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

        // Display all the choices, if there are any!
        if (story.currentChoices.Count > 0)
        {
            choice0 = story.currentChoices[0];
            choice1 = story.currentChoices[1];

            variant1.text = choice0.text.Trim();
            variant2.text = choice1.text.Trim();
        }
        // If we've read all the content and there's no choices, the story is finished!
        else
        {
            variant1.text = "End of the day";
            variant2.text = "End of the day";
        }

        ChoiseSelecter();
    }

    void ChoiseSelecter()
    {
        if (Swipe_detector.directionX == -1)
        {
            story.ChooseChoiceIndex(choice0.index);
        }
        else if(Swipe_detector.directionX == 1)
        {
            story.ChooseChoiceIndex(choice1.index);
        }
        
        Swipe_detector.Reset_SwipeX();
        RefreshView();
    }

}
