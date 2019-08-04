using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRoadTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider Collider)
    {
		Debug.Log("EndRoadTrigger.OnTriggerEnter.Collided : "+Collider.gameObject.tag);
        if(Collider.gameObject.CompareTag("Player")){
			Collider.gameObject.GetComponentInParent<ProceduralGenerator>().RoadEnded();
       }
    }

	private void OnTriggerExit(Collider Collider) {
	Debug.Log("EndRoadTrigger.OnTriggerExit.Collided : "+Collider.gameObject.tag);
        if(Collider.gameObject.CompareTag("Player")){
			Destroy(this.gameObject.transform.parent.gameObject);
	 	}
	}

}
