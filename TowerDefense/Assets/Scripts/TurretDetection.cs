using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDetection : MonoBehaviour {

    public Turret turret;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "enemy")
        {
            if(other.GetComponent<Spider>() != null)
            {
                int enemyID = other.GetComponent<Spider>().id;
                other.GetComponent<Spider>().IsMarkedForAttack = true;
                //Debug.Log("Attempting to mark enemy");
                EnemyTracker.Instance.ActivateTurret(turret.id, enemyID);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "enemy")
        {
            if (other.GetComponent<Spider>() != null)
            {
                int enemyID = other.GetComponent<Spider>().id;
                other.GetComponent<Spider>().IsMarkedForAttack = false;
                Debug.Log("Attempting to unmark enemy");
                for (int i = 0; i < turret.enemiesToAttack.Count; i++)
                {
                    if(turret.enemiesToAttack[i].GetComponent<Spider>().id == enemyID)
                    {
                        turret.enemiesToAttack.Remove(turret.enemiesToAttack[i]);
                    }
                }
                //EnemyTracker.Instance.DeactivateTurret(turret.id, enemyID);
            }
        }
    }
}
