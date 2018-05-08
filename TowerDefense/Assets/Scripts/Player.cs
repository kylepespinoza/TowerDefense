using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject cursor;
    float distanceToCursor;

    private void Update()
    {
        transform.LookAt(cursor.transform.position);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        distanceToCursor = Vector3.Distance(transform.position, cursor.transform.position);
        if(distanceToCursor > 2f)
        {
            transform.Translate(Vector3.forward);
        }
    }

}
