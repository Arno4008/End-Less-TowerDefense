using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slots : MonoBehaviour
{
    public GameObject tower;
    private new Camera camera;
    void Start()
    {
        camera = Camera.main;
    }


    private void OnMouseDown()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Slots") && hit.collider != null)
            {
                GameObject selectedSlot = hit.collider.gameObject;
                if (selectedSlot.transform.childCount == 0)
                {
                    Instantiate(tower, selectedSlot.transform.position, Quaternion.identity, selectedSlot.transform);
                }
            }
        }
    }
}
