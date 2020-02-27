using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    public List<GameObject> levelparts;
    private List<GameObject> wayPointList = new List<GameObject>();
    private List<GameObject> partReNaming = new List<GameObject>();
    public GameObject Waypoint;
    public GameObject levelStart;
    public GameObject levelEnd;
    private float nextLevelPositionZ = 1;
    private float nextLevelPositionX = 0;
    public int setMaxLevelSize = 100;
    private int currentLevelSize;
    private Vector3 startingPoint;
    private bool isLevelDone = false;
    public float partScaleX = 1;
    public float partScaleZ = 1;
    public int levelWidth;
    public bool randomWidth;

    public int wayPointCount;
    private Vector3 wayPointPosition;


    // Start is called before the first frame update
    void Start()
    {
       
        startingPoint = transform.position;
        Instantiate(levelStart, startingPoint, levelStart.transform.rotation);
        Instantiate(Waypoint, startingPoint, Waypoint.transform.rotation);
        currentLevelSize = 1;
        if (randomWidth) {
            if(levelWidth<20) { levelWidth = 20; }
            levelWidth = Random.Range(20, levelWidth);
        }
        CreateLevel();
        

    }

    // Update is called once per frame
    void Update()
    {
        
       
    }

    public void CreateLevel() 
    {
        int randomEndLevel = Random.Range(0, setMaxLevelSize);
        Debug.Log(randomEndLevel);
        for (int a = 0; a < setMaxLevelSize; a++)
        {

            if (isLevelDone) { return; }

            if (nextLevelPositionZ < levelWidth)
            {
                int randomLevel = Random.Range(0, levelparts.Count);
                if (randomEndLevel == currentLevelSize)
                {
                    wayPointList.Add(Instantiate(Waypoint, new Vector3(nextLevelPositionX * partScaleX, startingPoint.y, nextLevelPositionZ * partScaleZ), Waypoint.transform.rotation) as GameObject);
                    partReNaming.Add(Instantiate(levelEnd, new Vector3(nextLevelPositionX * partScaleX, startingPoint.y, nextLevelPositionZ * partScaleZ), levelStart.transform.rotation) as GameObject);
                    partReNaming[currentLevelSize - 1].name = "Level End piece: " + currentLevelSize;
                    wayPointList[currentLevelSize - 1].name = "waypoint: End Level";
                    currentLevelSize++;
                }
                else
                {
                    wayPointList.Add(Instantiate(Waypoint, new Vector3(nextLevelPositionX * partScaleX, startingPoint.y, nextLevelPositionZ * partScaleZ), Waypoint.transform.rotation) as GameObject);
                    partReNaming.Add(Instantiate(levelparts[randomLevel], new Vector3(nextLevelPositionX * partScaleX, startingPoint.y, nextLevelPositionZ * partScaleZ), levelparts[randomLevel].transform.rotation) as GameObject);
                    partReNaming[currentLevelSize - 1].name = "" + currentLevelSize;
                    wayPointList[currentLevelSize - 1].name = "waypoint: " + currentLevelSize;
                    currentLevelSize++;
                }

                if (currentLevelSize == setMaxLevelSize)
                {
                    isLevelDone = true;
                }
                nextLevelPositionZ++;

                if (nextLevelPositionZ == levelWidth)
                {
                    nextLevelPositionX++;
                    nextLevelPositionZ = 1;
                }

            }
        }   
        
    }

    public void RandomWayPoints()
    {

    }
    
}
