using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    
    public int speed=250;
    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, Time.deltaTime * speed, 0, Space.Self);
    }
}
