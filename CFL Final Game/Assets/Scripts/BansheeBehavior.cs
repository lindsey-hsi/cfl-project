using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BansheeBehavior : MonoBehaviour
{
    public Transform character;
    public Transform patrolRoute;
    public List<Transform> locations;
    private int locationIndex = 0;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        character = GameObject.Find("Character").transform;
        InitializePatrolRoute();
        MoveToNextPatrolLocation();
    }

    void InitializePatrolRoute()
    {
        foreach(Transform child in patrolRoute)
        {
            locations.Add(child);
        }
    }

    void MoveToNextPatrolLocation()
    {
        if(locations.Count == 0)
            return;
        agent.destination = locations[locationIndex].position;
        locationIndex = (locationIndex + 1) % locations.Count;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("TESTER!!!");
        if(other.name == "Character")
        {
            agent.destination = character.position;
            Debug.Log("Character detected – attack!");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.name == "Character")
        {
            Debug.Log("Character out of range, resume patrol.");
        } 
    }

    // Update is called once per frame
    void Update()
    {
       if(agent.remainingDistance < 0.2f && !agent.pathPending)
       {
           MoveToNextPatrolLocation();
       }
    }
}
