using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayButton : MonoBehaviour
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
            if (hit.collider.gameObject.CompareTag("PlayButton") && hit.collider != null)
            {
                SceneManager.LoadScene("MainScene");
            }
        }
    }
}
