using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
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
            if (hit.collider.gameObject.CompareTag("MainMenu") && hit.collider != null)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
