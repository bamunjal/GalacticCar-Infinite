using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarDynamics : MonoBehaviour
{
    public float topSpeed = 100f;
    public Text speedoMeter;
    public GameObject speedLines;

    public float currentSpeed = 0;
    private float pitch = 0;

    void Update()
    {
        currentSpeed = transform.GetComponent<Rigidbody>().velocity.magnitude * 6f;

        pitch = currentSpeed / topSpeed;
        GetComponent<AudioSource>().pitch = (pitch);

        //Debug.Log(currentSpeed); // Showcase current speed
        currentSpeed = Mathf.Ceil(currentSpeed);
        speedoMeter.text = currentSpeed.ToString() + " KPH";

        if (currentSpeed > 100)
        {
            speedoMeter.color = Color.red;
            speedLines.GetComponent<ParticleSystem>().Play();
        }
        else if (currentSpeed > 80)
        {
            speedoMeter.color = new Color(255, 69, 0);
            //    speedLines.GetComponent<ParticleSystem>().Stop();
        }
        else
        {
            // speedLines.GetComponent<ParticleSystem>().Stop();
        }
    }

}
