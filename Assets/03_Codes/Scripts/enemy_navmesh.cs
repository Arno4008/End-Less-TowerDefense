using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

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
        agent.updateRotation = false;
    }

    public void Move(Transform Exit)
    {
        agent.SetDestination(Exit.position);
    }
    void Update()
    {
        if (hp <= 0)
        {
            Debug.Log("Mort EnemyName: " + gameObject.name);
            manager.money += 20;
            Destroy(gameObject);
        }
        transform.rotation = Quaternion.LookRotation(agent.velocity.normalized);
        if (!agent.hasPath)
        {
            Debug.Log("Erreur Path");
            return;
        }
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            manager.current_hp -= damage;
            Debug.Log("Damage! HP: " + manager.current_hp);
            Debug.Log("EnemyName: " + gameObject.name);
            Destroy(gameObject);
        }
    }
}
