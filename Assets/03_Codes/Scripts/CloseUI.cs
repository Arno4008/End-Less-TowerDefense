using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseUI : MonoBehaviour
{
    public GameObject Canvas;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;

            if (touch.phase == TouchPhase.Began)
            {
                RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);
                if (hit.collider != null && hit.collider.gameObject.CompareTag("CloseUI"))
                {
                    GameObject selectedSlot = hit.collider.gameObject;
                    if (selectedSlot.transform.childCount == 0)
                    {
                        Canvas.SetActive(false);
                    }
                }
            }
        }
    }
}
