using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaController : MonoBehaviour {

    public GameObject sea;
    private float fireDistance = 0.5f;
    private GameObject[] fireList;
    public float seaLevel = 0;

	// Use this for initialization
	void Start () {
        CheckSeaLevel();
        
	}
	
	// Update is called once per frame
	void Update () {
        CheckSeaLevel();
        sea.transform.position = Vector3.Lerp(sea.transform.position, new Vector3(0, seaLevel, 0), Time.deltaTime/1.0f);
    }

    public void CheckSeaLevel()
    {
        fireList = GameObject.FindGameObjectsWithTag("flame");
        float newLevel = FindLowest() - fireDistance;
        if (seaLevel != newLevel){
            seaLevel = newLevel;
        }
    }

    float FindLowest()
    {
        float lowest = fireList[0].transform.position.y;
        foreach (GameObject fire in fireList)
        {
            if (fire.transform.position.y < lowest)
            {
                lowest = fire.transform.position.y;
                Debug.Log(fire.name);
            }
        }

        return lowest;
    }
}
