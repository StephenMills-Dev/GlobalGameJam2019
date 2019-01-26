using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using System;

public class CarNavAgent : MonoBehaviour {

    public GameObject startingPoint;
    public List<GameObject> listWaypoints;
    Vector3 currentWaypoint;
    Vector3 previousWaypoint;
    Vector3 nextWaypoint;
    NavMeshAgent agent;

    private void OnTriggerEnter(Collider other)
    {
        previousWaypoint = nextWaypoint;
        currentWaypoint = other.transform.position;
        listWaypoints.Clear();
        foreach (var item in other.GetComponent<Waypoint>().AdjacentWaypoints)
        {
            listWaypoints.Add(item);
        }
    }


    // Use this for initialization
    void Start () {
        foreach (var item in startingPoint.GetComponent<Waypoint>().AdjacentWaypoints)
        {
            listWaypoints.Add(item);
        }

        transform.position = startingPoint.transform.position;
        currentWaypoint = startingPoint.transform.position;
        previousWaypoint = startingPoint.transform.position;
        agent = GetComponent<NavMeshAgent>();
        ChooseNextPosition();
        
    }
	
	// Update is called once per frame
	void Update () {


        if (nextWaypoint == currentWaypoint)
        {
            ChooseNextPosition();
        }
        currentWaypoint = transform.position;
	}

    private void ChooseNextPosition()
    {
        int random = UnityEngine.Random.Range(0, listWaypoints.Count);
        nextWaypoint = listWaypoints[random].transform.position;
        if (nextWaypoint != previousWaypoint)
        {
            agent.SetDestination(nextWaypoint);

        }
        else
        {
            listWaypoints.Remove(listWaypoints[random]);
            random = UnityEngine.Random.Range(0, listWaypoints.Count);
            nextWaypoint = listWaypoints[random].transform.position;
            agent.SetDestination(nextWaypoint);

        }
        
    }
}
