using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndNPCTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerExit(Collider Collider)
    {
        Debug.Log("EndNPCTrigger.OnTriggerExit.Collided : " + Collider.gameObject.tag);
        if (Collider.gameObject.CompareTag("NPC") || Collider.gameObject.CompareTag("Collectible"))
        {
            if (Collider.gameObject.transform.parent)
            {
                Destroy(Collider.gameObject.transform.parent.gameObject);
            }
            else
            {
                Destroy(Collider.gameObject);
            }
        }
    }

}
