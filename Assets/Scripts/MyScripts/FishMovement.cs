using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public Transform fish;
    float fishY;
    float totalTime;
    float timeSinceAttack;
    float timeToDespawn;
    float fishDrag = 0.15f;
    float fishAttackSpeed = 15f;
    bool fishRises;
    bool fishIsDead;
    // Start is called before the first frame update
    void Start()
    {
        fishY = fish.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceAttack += Time.deltaTime;

        if (fishIsDead == false)
        {
            if (timeSinceAttack < 5)
            {
                FishRiseAndFall();
            }
            else
            {
                FishAttack();
            }
        }
    }

    void FishRiseAndFall()
    {
        if (totalTime > 2.5f)
        {
            fishRises = true;
            fishDrag = 0.15f;
        }
        else if (totalTime < 0)
        {
            fishRises = false;
            fishDrag = 0.15f;
        }
        if (fishRises == false)
        {
            fish.Translate(new Vector3(0, -fishDrag, 0) * Time.deltaTime);
            totalTime += Time.deltaTime;
            fishDrag -= Time.deltaTime * 0.2f;
        }
        else if (fishRises == true)
        {
            fish.Translate(new Vector3(0, fishDrag, 0) * Time.deltaTime);
            totalTime -= Time.deltaTime;
            fishDrag -= Time.deltaTime * 0.2f;
        }
    }

    void FishAttack()
    {
        if(timeSinceAttack < 7.96f)
        {
            fish.Translate(new Vector3(0, fishAttackSpeed, 0) * Time.deltaTime);
            fishAttackSpeed -= Time.deltaTime * 10f;
        }
        else
        {
            fish.position = new Vector3(fish.position.x, fishY, fish.position.z);
            totalTime = 0;
            fishRises = false;
            fishDrag = 0.15f;
            fishAttackSpeed = 15f;
            timeSinceAttack = 0;
        }   
    }

    public void Death()
    {
        fishIsDead = true;
        timeToDespawn += Time.deltaTime;
        fish.Translate(new Vector3(0, -timeToDespawn, 0) * Time.deltaTime, Space.World);
        if (timeToDespawn > 7)
        {
            Destroy(gameObject);
        }
    }
}
