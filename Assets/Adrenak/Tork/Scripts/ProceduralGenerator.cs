using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGenerator : MonoBehaviour, TriggerInterface
{
    public GameObject world;
    public FourLaneRoadStraight FourLaneRoadStraightPrefab;
    public FourLaneRoadRight FourLaneRoadRightPrefab;
    public GameObject Collectibles;

    public NPCMotor[] NPCs;
    private Road currentEndObject;

    private int[] NPCPositions = { -5, -2, 2, 5 };
    private bool isCollectible=false;



    // Start is called before the first frame update
    void Start()
    {
        GameObject newWorld = GameObject.Instantiate(world);
        newWorld.transform.position = new Vector3(0, 0, 0);
        world = newWorld;
        FourLaneRoadStraight firstRoad = Instantiate(FourLaneRoadStraightPrefab);
        firstRoad.transform.parent = newWorld.transform;
        FourLaneRoadStraight secondRoad = Instantiate(FourLaneRoadStraightPrefab);
        secondRoad.transform.parent = newWorld.transform;

        Debug.Log("Road.length : " + firstRoad.length);
        secondRoad.transform.position = new Vector3(firstRoad.transform.position.x, firstRoad.transform.position.y, firstRoad.transform.position.z + firstRoad.length);
        currentEndObject = secondRoad;
        StartCoroutine(NPCSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        // NPCSpawner();
    }

    public void RoadEnded()
    {
        Debug.Log("RoadEnded.Creating new road !");
        FourLaneRoadStraight newRoad = Instantiate(FourLaneRoadStraightPrefab);
        newRoad.transform.parent = world.transform;
        if (currentEndObject.CurrentDirection == Road.direction.right)
        {
            newRoad.transform.Rotate(0, 90, 0);
            newRoad.transform.position = new Vector3(currentEndObject.transform.position.x + currentEndObject.length, currentEndObject.transform.position.y, currentEndObject.transform.position.z);
        }
        else if (currentEndObject.CurrentDirection == Road.direction.straight)
        {
            newRoad.transform.position = new Vector3(currentEndObject.transform.position.x, currentEndObject.transform.position.y, currentEndObject.transform.position.z + currentEndObject.length);
        }
        currentEndObject = newRoad;
    }

    private IEnumerator NPCSpawner()
    {
        while (true)
        {
            if (GetComponent<CarDynamics>().currentSpeed > 50)
            {
                if (isCollectible)
                {
                    generateCollectibles();
                    isCollectible=false;
                }
                else
                {
                    generateNPC();
                    isCollectible=true;
                }
            }
            yield return new WaitForSeconds(2);
        }
    }

    private void generateNPC()
    {
        NPCMotor instance = Instantiate(NPCs[Random.Range(0, NPCs.Length)]);
        instance.direction = -1;
        instance.transform.position = new Vector3(NPCPositions[Random.Range(0, NPCPositions.Length)], this.transform.position.y, this.transform.position.z + currentEndObject.length);
    }

    private void generateCollectibles()
    {
        GameObject instance = GameObject.Instantiate(Collectibles);
        instance.transform.position = new Vector3(NPCPositions[Random.Range(0, NPCPositions.Length)], this.transform.position.y + 0.5f, this.transform.position.z + (currentEndObject.length-30));
    }

}