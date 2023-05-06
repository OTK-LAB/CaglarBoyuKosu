using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTutorial : Tutorial
{
    private bool isCurrentTutorial = false;
    public List<KeyCode> Keys = new List<KeyCode>();

    private bool isFinishLinePassed = false;

    
    public override bool CheckIfHappening()
    {
        if (!isFinishLinePassed)
        {
            if (FýnýshLine.instance.isFinished == true)
            {
                
                for (int i = 0; i < Keys.Count; i++)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        Keys.RemoveAt(i);
                        break;
                    }
                }

                if (Keys.Count == 0)
                {
                    TutorialManager.Instance.CompletedTutorial();
                    isFinishLinePassed = true;
                }
            }
        }
        return base.CheckIfHappening();
    }
}
