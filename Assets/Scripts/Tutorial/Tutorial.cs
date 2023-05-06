using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public int Order;

    [TextArea(3, 10)]
    public string Explanation;

    public bool ShowExplanation = true;

    void Awake()
    {
        TutorialManager.Instance.Tutorials.Add(this);
    }

    public virtual bool CheckIfHappening()
    {
        bool conditionMet = CheckCondition();
        if (conditionMet)
        {
            
            TutorialManager.Instance.SetTutorialCondition(Order, true);
        }

        return conditionMet;
    }


    public bool CheckCondition()
    {
        switch (Order)
        {
            case 0:
                return true;

            case 1:
                if(FýnýshLine.instance.isFinished == true)
                {
                    return true;
                }
                break;
        }

        return false;
    }
}
