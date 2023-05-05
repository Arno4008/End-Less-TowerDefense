using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy_navmesh : MonoBehaviour
{
    public int damage;
    public int gain;
    public int XP;
    public int hp;
    private NavMeshAgent agent;
    private Manager manager;

    void Awake()
    {
        manager = FindObjectOfType<Manager>();
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
            manager.current_hp -= damage;
            Debug.Log("Damage! HP: " + manager.current_hp);
            Destroy(gameObject);
        }
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
