using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public GameObject spider;
    public int range;

	void Start () {
		
	}
	
	void Update () {
        transform.LookAt(spider.transform.position);

	}

}
