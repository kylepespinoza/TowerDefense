using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracker : MonoBehaviour
{

    [HideInInspector]
    public int turretID;
    public int enemyID;

    private static EnemyTracker _instance;
    public static EnemyTracker Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<EnemyTracker>();
            return _instance;
        }
    }

    public List<Enemy> enemyList = new List<Enemy>();
    public List<Turret> turretList = new List<Turret>();

    //Each turret has a unique ID starting at 1. Each enemy has a unique ID starting at 1.
    public int GenerateID(string type)
    {
        if (type == "turret")
        {
            turretID++;
            return turretID;
        }
        else if (type == "enemy")
        {
            enemyID++;
            return enemyID;
        }
        else
        {
            return 0;
        }
    }

    public void ActivateTurret(int turretID, int enemyID)
    {
        //Enemy notifies the tracker that it's within a turret's attack range, and the tracker tells the turret to add it to the attack queue if it's not the only one
        turretList[turretID - 1].enemiesToAttack.Add(enemyList[enemyID - 1]);
        //Debug.Log("Turret: " + turretID + " is targeting Enemy: " + enemyID);
        turretList[turretID - 1].activeTarget = enemyList[enemyID - 1].gameObject;
        turretList[turretID - 1].Initialize = true;
    }

    public void DeactivateTurret(int turretID, int enemyID)
    {
        turretList[turretID - 1].activeTarget = null;
        turretList[turretID - 1].Initialize = false;
    }

    public void RemoveEnemy(int enemyID)
    {
        //Enemy has died and is removed from the list -- But this changes the list order and breaks everything...
        //enemyList.RemoveAt(enemyID - 1);
        for (int i = 0; i < turretList.Count; i++)
        {
            if (turretList[i].activeTarget.GetComponent<Spider>().id == enemyID)
            {
                //The turret that killed the enemy clears it's active target slot
                turretList[i].GetComponent<Turret>().enemiesToAttack.RemoveAt(0);
                turretList[i].GetComponent<Turret>().activeTarget = null;
            }
        }
    }
}
