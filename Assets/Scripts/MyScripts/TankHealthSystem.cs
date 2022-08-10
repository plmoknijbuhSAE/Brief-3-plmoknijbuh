using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHealthSystem : MonoBehaviour
{
    public GameObject tank;
    public GameObject tankExplosion;
    public GameObject tankDeathExplosion;
    public GameObject deadTank;
    float totalTime;
    int health = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Death();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            health--;
            if(health > 0)
            {
                Instantiate(tankExplosion, tank.transform);
            }
        }
    }
    
    void Death()
    {
        if(health <= 0)
        {
            Vector3 tankPosition = new Vector3(tank.transform.position.x, tank.transform.position.y, tank.transform.position.z);
            Quaternion tankRotation = tank.transform.rotation;
            Instantiate(deadTank, tankPosition, tankRotation);
            Instantiate(tankDeathExplosion, tankPosition, tankRotation);
            Destroy(gameObject);

        }
    }
}
