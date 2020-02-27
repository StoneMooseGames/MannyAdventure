using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    public GameObject player;
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

    private Vector3 wayPointPosition;
    


    // Start is called before the first frame update
    void Start()
    {
       
        
        currentLevelSize = 1;
        if (randomWidth) {
            if(levelWidth<20) { levelWidth = 20; }
            levelWidth = Random.Range(20, levelWidth);
        }
        CreateLevel();
        startingPoint = GameObject.FindGameObjectWithTag("levelstart").gameObject.transform.position;
        player.gameObject.transform.position = startingPoint + new Vector3(1, 1, 1);
        

    }

    // Update is called once per frame
    void Update()
    {
        
       
    }

    public void CreateLevel() 
    {
        Vector3 returnPlayerStartpoint = new Vector3(0,0,0);
        
        int randomEndLevel = Random.Range(0, setMaxLevelSize);
        int randomStartLevel = Random.Range(0, setMaxLevelSize);

        Debug.Log(randomStartLevel + " is level start and " + randomEndLevel + " is end");
       
        for (int a = 0; a < setMaxLevelSize; a++)
        {

            if (isLevelDone) { return;  }

            if (nextLevelPositionZ < levelWidth)
            {
                int randomLevel = Random.Range(0, levelparts.Count);
                if (randomEndLevel == currentLevelSize)
                {
                    
                    wayPointList.Add(Instantiate(Waypoint, new Vector3(nextLevelPositionX * partScaleX, transform.position.y, nextLevelPositionZ * partScaleZ), Waypoint.transform.rotation) as GameObject);
                    partReNaming.Add(Instantiate(levelEnd, new Vector3(nextLevelPositionX * partScaleX, transform.position.y, nextLevelPositionZ * partScaleZ), levelEnd.transform.rotation) as GameObject);
                    partReNaming[currentLevelSize - 1].name = "Level End piece: " + currentLevelSize;
                    partReNaming[currentLevelSize - 1].gameObject.tag = "levelend";
                    wayPointList[currentLevelSize - 1].name = "waypoint: End Level";
                    currentLevelSize++;
                    
                }
                if (randomStartLevel == currentLevelSize)
                {
                    wayPointList.Add(Instantiate(Waypoint, new Vector3(nextLevelPositionX * partScaleX, transform.position.y, nextLevelPositionZ * partScaleZ), Waypoint.transform.rotation) as GameObject);
                    partReNaming.Add(Instantiate(levelStart, new Vector3(nextLevelPositionX * partScaleX, transform.position.y, nextLevelPositionZ * partScaleZ), levelStart.transform.rotation) as GameObject);
                    partReNaming[currentLevelSize - 1].name = "Level Start piece: " + currentLevelSize;
                    partReNaming[currentLevelSize - 1].gameObject.tag = "levelstart"; 
                    wayPointList[currentLevelSize - 1].name = "waypoint: Start Level";
                    currentLevelSize++;
                }
                else
                {
                    
                    wayPointList.Add(Instantiate(Waypoint, new Vector3(nextLevelPositionX * partScaleX, transform.position.y, nextLevelPositionZ * partScaleZ), Waypoint.transform.rotation) as GameObject);
                    partReNaming.Add(Instantiate(levelparts[randomLevel], new Vector3(nextLevelPositionX * partScaleX, transform.position.y, nextLevelPositionZ * partScaleZ), levelparts[randomLevel].transform.rotation) as GameObject);
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
