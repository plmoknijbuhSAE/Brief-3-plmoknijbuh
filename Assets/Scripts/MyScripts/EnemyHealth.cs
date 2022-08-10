using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject enemyObj;
    public int healthPoints;

    // Start is called before the first frame update
    void Start()
    {
        healthPoints = 2;
    }

    // Update is called once per frame
    void Update()
    {
        DeathCounter();
    }
    
    void DeathCounter()
    {
        if (healthPoints <= 0)
        {
            enemyObj.transform.rotation = Quaternion.Euler(25, 30, -40);
            enemyObj.GetComponent<FishMovement>().Death();
        }
    }
}
