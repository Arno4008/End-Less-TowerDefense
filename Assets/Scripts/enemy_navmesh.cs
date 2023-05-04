using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy_navmesh : MonoBehaviour
{
    public int damage;
    public int gain;
    public int XP;
    private NavMeshAgent agent;

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
        {
            Debug.Log("Damage! HP: " + Var.Instance.hp);
            Var.Instance.hp -= damage;
            Var.Instance.monnaie += gain;
            Var.Instance.xp += XP;
            Destroy(gameObject);
        }
    }
}
