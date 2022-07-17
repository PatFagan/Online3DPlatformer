using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public abstract class GoapAction : MonoBehaviour
{
    NavMeshAgent navMeshAgent;

    public int cost;
    public Dictionary<string, bool> preconditions = new Dictionary<string, bool>();

    public float speed;

    public abstract bool CheckPreconditions();
    public abstract void RunAction();

    public GoapAgent goapAgentScript;

    // set target loc by finding target object by tag
    public void SetTarget(string targetTag)
    {
        GameObject target = GameObject.Find(targetTag);
        MoveToLoc(target.transform.position);
    }

    // move to target loc using navmesh
    void MoveToLoc(Vector3 targetLoc)
    {
        navMeshAgent.SetDestination(targetLoc);
    }
}