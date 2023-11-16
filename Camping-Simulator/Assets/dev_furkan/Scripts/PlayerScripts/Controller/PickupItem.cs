using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public GameObject itemPrefab;

    public void PickUp()
    {
        gameObject.SetActive(false);
    }
}
