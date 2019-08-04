using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public enum direction {
        straight,
        left,
        right
    }
    public int length;
    public direction CurrentDirection;
}
