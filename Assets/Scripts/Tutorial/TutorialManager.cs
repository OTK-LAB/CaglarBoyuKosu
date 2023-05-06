using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public List<Tutorial> Tutorials = new List<Tutorial>();
    public Text expText;
    public bool conditionMet = true;


    private static TutorialManager instance;
    public static TutorialManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<TutorialManager>();

            if (instance == null)
                Debug.Log("There is no TutorialManager");

            return instance;
        }
    }

    private Tutorial currentTutorial;

    // Start is called before the first frame update
    void Start()
    {
        SetNextTutorial(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTutorial != null)
        {
            bool conditionMet = currentTutorial.CheckIfHappening();

            if (conditionMet && currentTutorial != null)
            {
                expText.text = currentTutorial.Explanation;
            }
            else
            {
                expText.text = "Condition not met";
            }
        }
    }



    public void CompletedTutorial()
    {
        SetNextTutorial(currentTutorial.Order + 1);
    }

    public void SetNextTutorial(int currentOrder)
    {
        currentTutorial = GetTutorialByOrder(currentOrder);

        if (currentTutorial == null)
        {
            CompletedAllTutorials();
            return;
        }
    }


    public void CompletedAllTutorials()
    {
        expText.text = "You have completed all the tutorials, Well done!";
    }

    public Tutorial GetTutorialByOrder(int Order)
    {
        for (int i = 0; i < Tutorials.Count; i++)
        {
            if (Tutorials[i].Order == Order)
                return Tutorials[i];
        }

        return null;
    }

    public void SetTutorialCondition(int order, bool condition)
    {
        if (currentTutorial != null && (condition && order == currentTutorial.Order))
            conditionMet = true;
        else
            conditionMet = false;
    }

}
