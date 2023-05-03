using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class enemy : MonoBehaviour
{
    public List<Transform> Waypoints;
    private Vector3 direction;
    public float speed = 1.0f;
    private int x = 0;
    private int b = 1;
    private float journeyLength;
    private float startTime;

    void Start()
    {
        // Enregistrez le temps de départ
        startTime = Time.time;

        // Calculez la distance entre les points A et B
        journeyLength = Vector3.Distance(Waypoints[0].position, Waypoints[1].position);

        // Définir la position initiale du GameObject
        transform.position = Waypoints[0].position;
    }

    void Update()
    {
        // Calculez la fraction du voyage accompli
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        if (transform.position != Waypoints[Waypoints.Count - 1].position)
        {
            // Déplacez le GameObject entre les points A et B
            transform.position = Vector3.Lerp(Waypoints[x].position, Waypoints[b].position, fracJourney);
            if (transform.position == Waypoints[b].position)
            {
                // Enregistrez le temps de départ
                startTime = Time.time;
                x++;
                b++;
                if (transform.position != Waypoints[Waypoints.Count - 1].position)
                {
                    journeyLength = Vector3.Distance(Waypoints[x].position, Waypoints[b].position);
                }
            }
        }
    }
}