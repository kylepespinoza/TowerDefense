using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour {

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveCursorToMouse();
        }
    }

    void MoveCursorToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            //Raycast events.... duh
            //Debug.Log(hit.collider.gameObject.name);
        }

        transform.position = hit.point;
    }
}
