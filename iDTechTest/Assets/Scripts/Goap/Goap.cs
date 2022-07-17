using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goap : MonoBehaviour
{
    public List<GoapAction> GoapActions;
    public List<GoapAction> initalGoapActions;

    public GameObject goapActionKeeper;
    public bool runningGoap;
    public bool isActing;

    bool gnomeRunning = false;

    public float timeBetweenActions;
    public bool pausedGoap;

    /*
    GapClosingLeap leapScript;
    MeleeAttack meleeScript;
    RangedAttack rangedScript;
    void setListOfGoapActions()
    {
        leapScript = goapActionKeeper.GetComponent<GapClosingLeap>();
        GoapActions[0] = leapScript;
        initalGoapActions[0] = leapScript;

        meleeScript = goapActionKeeper.GetComponent<MeleeAttack>();
        GoapActions[1] = meleeScript;
        initalGoapActions[1] = meleeScript;

        rangedScript = goapActionKeeper.GetComponent<RangedAttack>();
        GoapActions[2] = rangedScript;
        initalGoapActions[2] = rangedScript;

    }
    */

    void Start()
    {
        // get all goap actions
        //setListOfGoapActions();

        // sort goap actions by cost, from least to greatest
        //gnomeSort(GoapActions);

        // start goap cycle
        if (runningGoap)
            StartCoroutine(RunState());
    }

    public void NextState()
    {
        StartCoroutine(RunState());
    }

    IEnumerator RunState()
    {
        yield return new WaitForSeconds(timeBetweenActions);

        //gnomeSort(GoapActions);

        // run through goap actions
        // run first action with all preconditions met
        for (int i = GoapActions.Count - 1; i >= 0; i--)
        {
            if (GoapActions[i].CheckPreconditions())
            {
                //loops through the inital order of the actions
                for (int j = 0; j < initalGoapActions.Count; ++j)
                {
                    //Checks what action should be run with inital order to send to all clients
                    if (initalGoapActions[j] == GoapActions[i])
                    {
                        initalGoapActions[i].RunAction();
                        break;
                    }
                }
                break;
            }
        }

        yield return new WaitUntil(() => pausedGoap == false);
        StartCoroutine(RunState());
    }

    // sort goap actions by cost
    void gnomeSort(List<GoapAction> list)
    {
        gnomeRunning = true;

        int i = 0;

        while (i < list.Count)
        {
            if (i == 0)
                i++;
            if (list[i - 1].cost >= list[i].cost)
                i++;
            else
            {
                swapVar(list[i], list[i - 1]);
                i--;
            }
        }

        //print("SORTED: " + list[0] + " COST: " + list[0].cost);
        //print("SORTED: " + list[1] + " COST: " + list[1].cost);
        //print("SORTED: " + list[2] + " COST: " + list[2].cost);

        gnomeRunning = false;
    }

    // swaps two values
    void swapVar(GoapAction a, GoapAction b)
    {
        GoapAction temp;
        temp = a;
        a = b;
        b = temp;
    }

}