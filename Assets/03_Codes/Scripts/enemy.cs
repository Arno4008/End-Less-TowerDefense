using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public List<Transform> Waypoints;
    public float speed = 1.0f;
    private int x = 0;
    private int b = 1;
    private float journeyLength;
    private float startTime;
    public int damage;
    public int gain;
    public int XP;
    public int hp;
    public Manager manager;

    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(Waypoints[0].position, Waypoints[1].position);
        transform.position = Waypoints[0].position;
    }

    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        if (transform.position != Waypoints[Waypoints.Count - 1].position)
        {
            transform.position = Vector3.Lerp(Waypoints[x].position, Waypoints[b].position, fracJourney);
            if (transform.position == Waypoints[b].position)
            {
                startTime = Time.time;
                x++;
                b++;
                if (transform.position != Waypoints[Waypoints.Count - 1].position)
                {
                    journeyLength = Vector3.Distance(Waypoints[x].position, Waypoints[b].position);
                }
            }
        }
        if (b == Waypoints.Count)
        {
            manager.current_hp -= damage;
            Debug.Log("Damage! HP: " + manager.current_hp);
            Destroy(gameObject);
        }
        if (hp <= 0)
        {
            manager.xp += XP;
            manager.money += gain;
            Destroy(gameObject);
        }
    }
}