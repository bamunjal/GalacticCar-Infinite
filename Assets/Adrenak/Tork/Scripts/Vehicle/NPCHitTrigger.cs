using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCHitTrigger : MonoBehaviour
{
    public Text collections;
    public int TotalCollections = 0;

    private void OnTriggerEnter(Collider Collider)
    {
        Debug.Log("CarDynamics.OnTriggerEnter.Collided : " + Collider.gameObject.tag);
        if (Collider.gameObject.CompareTag("Collectible"))
        {
            TotalCollections++;
            collections.text = TotalCollections.ToString();
            Destroy(Collider.gameObject);
        }
    }
}