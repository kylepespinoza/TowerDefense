using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : MonoBehaviour
{
    public GameObject activeTarget;
    public GameObject bullet;
    public GameObject bulletSpot;

    public GameObject laserBarrel;

    LineRenderer lineRenderer = new LineRenderer();

    bool readyToFire = true;

    public UnityStandardAssets.Cameras.LookatTarget lookAtComponent;

    //Each turret has an ID starting from 1
    public int id;

    bool attacking;

    Rigidbody barrelRigid;

    private bool initialize;
    public bool Initialize
    {
        get
        {
            return initialize;
        }
        set
        {
            initialize = value;
            if (value == true)
            {
                if(!attacking)
                Debug.Log("Calculating Enemy Distances");
                StartCoroutine(CalculateEnemyDistances());
                //StartCoroutine(ShootBullet());
                attacking = true;
            }
            else
            {
                attacking = false;
            }
        }
    }

    public List<Enemy> enemiesToAttack = new List<Enemy>();

    void Start()
    {
        //Adding myself to list of turrets
        EnemyTracker.Instance.turretList.Add(GetComponent<Turret>());
        id = EnemyTracker.Instance.GenerateID("turret");
        StartCoroutine(CalculateEnemyDistances());
        barrelRigid = laserBarrel.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (initialize)
        {
            if (activeTarget != null)
            {
                //Track enemy position if enemy has crossed into the turret range
                transform.LookAt(activeTarget.transform.position);
            }
        }
        barrelRigid.AddRelativeForce(20, 0, 0, ForceMode.Force);
    }
    IEnumerator CalculateEnemyDistances()
    {
        float closestEnemyDistance = 10000f;
        RemoveDeadEnemies();
        for (int i = 0; i < enemiesToAttack.Count; i++)
        {
            float dist = Vector3.Distance(enemiesToAttack[i].transform.position, transform.position);
            if (dist < closestEnemyDistance)
            {
                float distToActiveTarget = Vector3.Distance(activeTarget.transform.position, transform.position);
                closestEnemyDistance = dist;
                activeTarget = enemiesToAttack[i].gameObject;
                lookAtComponent.ChangeTarget(activeTarget);

            }
        }

        yield return new WaitForSeconds(.5f);
        if (enemiesToAttack.Count != 0)
        {
            StartCoroutine(CalculateEnemyDistances());
        }
        else
        {
            activeTarget = null;
        }

        if(readyToFire)
        {
           ShootLaser();
            StartCoroutine(ShootTimer());
        }
    }

    void RemoveDeadEnemies()
    {
        //Clearing the enemy list of fallen enemies
        for (int i = 0; i < enemiesToAttack.Count; i++)
        {
            if (enemiesToAttack[i].gameObject.tag == "dead") { enemiesToAttack.RemoveAt(i); }
        }
    }

    void ShootLaser()
    {
        
    }

    IEnumerator ShootTimer()
    {
        readyToFire = false;
        yield return new WaitForSeconds(3f);
        readyToFire = true;
    }
}
