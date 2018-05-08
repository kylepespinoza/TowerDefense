using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHover : MonoBehaviour {

    void Start()
    {
        GetComponent<Renderer>().material.color = Color.yellow;
    }

    void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = Color.cyan;
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = Color.yellow;
    }
}
