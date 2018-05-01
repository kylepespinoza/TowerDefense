using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public GameObject spider;

	void Start () {
		
	}
	
	void Update () {
        transform.LookAt(spider.transform.position);
	}
}
