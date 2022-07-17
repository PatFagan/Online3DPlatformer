using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : GoapAction
{
    public Collider handCollider;

    public ChasePlayer()
    {
        preconditions.Add("Hungry", true);
    }

    public override bool CheckPreconditions()
    {
        if (preconditions["Hungry"] == true)
            return true;
        else
            return false;
    }

    void Update()
    {
        preconditions["Hungry"] = goapAgentScript.hungry;
    }



    public override void RunAction()
    {
        //print("leaping, cost: " + cost);
        //goapAgentScript.currentAnimation = "Leap";

        SetTarget("Player");
    }
}