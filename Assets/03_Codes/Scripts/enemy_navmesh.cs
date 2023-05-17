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

    // Update is called once per frame
    void Update()
    {
        if(!agent.hasPath)
        {
            return;
        }

        transform.rotation = Quaternion.LookRotation(agent.velocity.normalized);

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            manager.current_hp -= damage;
            Debug.Log("Damage! HP: " + manager.current_hp);
            Destroy(gameObject);
        }
        if (hp <= 0)
        {
            manager.money += 20;
            Destroy(gameObject);
        }
        // Update the way to the goal every second.
        /*_wait += Time.deltaTime;
        if (_wait > 1.0f)
        {
            _wait -= 1.0f;
            NavMesh.CalculatePath(transform.position, GetComponent<NavMeshAgent>().destination, NavMesh.AllAreas, path);
        }
        for (int i = 0; i < path.corners.Length - 1; i++)
            Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);*/
    }
}
