using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShopController : MonoBehaviour
{
    private GameObject selectedSlot;
    private GameObject towerToInstantiate;

    public GameObject TowerToInstantiate
    {
        get { return towerToInstantiate; }
        set { towerToInstantiate = value; }
    }

    public void SetSelectedSlot(GameObject slot)
    {
        selectedSlot = slot;
    }
    public void BuyTower(GameObject towerPrefab)
    {
        towerToInstantiate = towerPrefab;
        if (selectedSlot != null)
        {
            if (selectedSlot.transform.childCount == 0)
            {
                Instantiate(towerPrefab, selectedSlot.transform.position, Quaternion.identity, selectedSlot.transform);
            }
        }
        CloseShop();
    }

    public void CloseShop()
    {
        gameObject.SetActive(false);
    }
}
