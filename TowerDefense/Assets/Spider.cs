using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour {

    float rotationMod;

    public float rotationSpeed;
    public float speed;

    Rigidbody rigid;

    private void Start()
    {
        StartCoroutine(ResetRotationMod());
        rigid = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Vector3.SqrMagnitude(rigid.velocity) < 50f) 
            rigid.AddRelativeForce(Vector3.forward * (speed * 450f) * Time.deltaTime, ForceMode.Force);
        rigid.AddRelativeTorque(0, (rotationMod * 45) * Time.deltaTime, 0);
    }

    IEnumerator ResetRotationMod()
    {
        if (Random.Range(1, 6) == 2)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * Random.Range(10, 24), ForceMode.Impulse);
        }
        speed = Random.Range(0, 4);
        rotationMod = Random.Range(-rotationSpeed, rotationSpeed);
        yield return new WaitForSeconds(Random.Range(1, 3));
        StartCoroutine(ResetRotationMod());
    }

    private void OnCollisionEnter(Collision collision)
    {
        float hitForce = Vector3.Magnitude(collision.impulse);
        if (collision.gameObject.name != "Ground")
        {
            Debug.Log(collision.gameObject.name + " hit with a force of " + hitForce);
        }
        if(hitForce > 25)
        {
            StartCoroutine(Explode());
        }
    }

    IEnumerator Explode()
    {
        for (int i = 0; i < transform.GetChild(0).transform.GetChild(2).childCount; i++)
        {
            transform.GetChild(0).transform.GetChild(2).GetChild(i).gameObject.AddComponent<Rigidbody>();
        }
        yield return new WaitForSeconds(.7f);
        transform.GetChild(0).transform.GetChild(2).DetachChildren();
        Destroy(gameObject, 10f);
    }
}
