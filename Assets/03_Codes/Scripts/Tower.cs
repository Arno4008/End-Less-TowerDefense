using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float Range;
    public int Damage;
    public float FireRate;
    private GameObject enemy;
    public float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= FireRate)
        {

            if (enemy == null)
            {            
                enemy = GameObject.FindGameObjectWithTag("Enemy");
            }
            if (enemy != null && Vector3.Distance(enemy.transform.position, transform.position) <= Range)
            {
                timer = 0;
                enemy.GetComponent<enemy_navmesh>().hp -= Damage;
                if (enemy.transform.position.x >= transform.position.x) 
                {
                    transform.GetChild(1).transform.localEulerAngles = new Vector3(0, -180, 0);
                } else
                {
                    transform.GetChild(1).transform.localEulerAngles = new Vector3(0, 180, 0);
                }
            }
        }
    }
}
