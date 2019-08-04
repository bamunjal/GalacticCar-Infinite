using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMotor : MonoBehaviour
{
    public int speed = 5;
    public int direction=1;
    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, (this.transform.position.z + (speed * Time.deltaTime*direction)));
    }
}
