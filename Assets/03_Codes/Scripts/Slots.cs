using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slots : MonoBehaviour
{
    public GameObject tower;
    private Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        // Do something with the object that was hit by the raycast.
        if (Physics.Raycast(ray, out hit))
        {
            if(hit.transform.tag == "Slots")
            {
                Instantiate(tower, transform.position, Quaternion.identity);
            }
        }
    }
}
