using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy_navmesh : MonoBehaviour
{
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Move(Transform Exit)
    {
        agent.destination = Exit.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance <= 1)
            Destroy(gameObject);
    }
}
