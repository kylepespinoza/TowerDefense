using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralCrystalCluster : MonoBehaviour {

    GameObject anchor1, anchor2, anchor3;
    GameObject[] anchorlist;

	void Start () {
        anchor1 = transform.GetChild(0).gameObject;
        anchor2 = transform.GetChild(1).gameObject;
        anchor3 = transform.GetChild(2).gameObject;
        anchorlist = new GameObject[3] { anchor1, anchor2, anchor3 };
        ArrangeAnchorPoints();
    }

    void Update () {
		
	}

    void ArrangeAnchorPoints()
    {
        for (int i = 0; i < anchorlist.Length; i++)
        {
            anchorlist[i].transform.position += new Vector3(Random.Range(-2f, 2f), 0, Random.Range(-2f, 2f));
            anchorlist[i].transform.localScale = new Vector3(Random.Range(1f, 2f), Random.Range(.5f, 1.5f), Random.Range(1f, 2f));
            anchorlist[i].transform.eulerAngles = new Vector3(0, Random.Range(0, 360f), 0);
        }
    }
}
