using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourLaneRoadStraight : Road
{
    public FourLaneRoadStraight(){
        length=100;
        CurrentDirection=direction.straight;
    }
}
