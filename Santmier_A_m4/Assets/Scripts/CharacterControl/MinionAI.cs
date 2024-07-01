using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MinionAI : MonoBehaviour
{
    public float lookAheadTime;
    public GameObject[] waypoints;
    public GameObject lookAheadMarker;

    NavMeshAgent agent;
    Animator anim;

    int currWaypoint;
    const int STATIC = 0;
    const int DYNAMIC = 1;
    int state;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        GotoStatic();

        currWaypoint = -1;
        setNextWaypoint();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("vely", agent.velocity.magnitude / agent.speed);
        if (state == STATIC)
        {
            if (agent.remainingDistance == 0 && !agent.pathPending)
            {
                setNextWaypoint();
            }
        } else if (state == DYNAMIC)
        {
            VelocityReporter vr = waypoints[currWaypoint].GetComponent<VelocityReporter>();
            Vector3 evel = vr.velocity;
            float distance = (waypoints[currWaypoint].transform.position - transform.position).magnitude;

            // Since we care about distance to the actual waypoint, we will not be using agent.remainingDistance
            if (distance < agent.stoppingDistance && !agent.pathPending)
            {
                setNextWaypoint();
            }

            float lookAheadT = Mathf.Clamp(distance / agent.speed, 0, lookAheadTime);
            Vector3 futureTarget = waypoints[currWaypoint].transform.position + (lookAheadT * evel);

            // If the predicted position is unreachable, just don't use prediction
            NavMeshHit hit;
            if (NavMesh.Raycast(transform.position, futureTarget, out hit, NavMesh.AllAreas))
            {
                futureTarget = waypoints[currWaypoint].transform.position;
            }

            agent.SetDestination(futureTarget);
            if (lookAheadMarker != null)
            {
                lookAheadMarker.transform.position = futureTarget;
            }
        }
    }

    private void setNextWaypoint()
    {
        if (waypoints.Length == 0)
        {
            Debug.LogError("No waypoints for minion to follow!");
            return;
        }
        currWaypoint = (currWaypoint + 1) % waypoints.Length;
        // Assume the third waypoint is always the moving one
        // A more practical solution would be tagging that waypoint, but this should be fine for this assignment
        if (currWaypoint == 2 && state == STATIC)
        {
            GotoDynamic();
        } else if (currWaypoint != 2 && state == DYNAMIC)
        {
            GotoStatic();
        }
        agent.SetDestination(waypoints[currWaypoint].transform.position);
    }

    private void GotoDynamic()
    {
        state = DYNAMIC;

        if (lookAheadMarker == null)
        {
            Debug.LogError("No look ahead marker on minion script!");
            return;
        }
        lookAheadMarker.SetActive(true);
    }

    private void GotoStatic()
    {
        state = STATIC;

        if (lookAheadMarker == null)
        {
            Debug.LogError("No look ahead marker on minion script!");
            return;
        }
        lookAheadMarker.SetActive(false);
    }
}
