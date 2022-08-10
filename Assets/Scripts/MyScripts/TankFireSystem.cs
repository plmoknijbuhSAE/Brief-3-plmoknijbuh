using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankFireSystem : MonoBehaviour
{
    public GameObject bullet;
    public Transform tankTurret;
    public TankMovementSideways tankHoldFire;
    public AudioClip tankFireClip;

    float totalTime;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        totalTime += Time.deltaTime;
        // Limits the attack speed so that the tank is not full-auto
        if(totalTime > 1)
        {
            BulletInstantiation();
        }
    }

    void BulletInstantiation()
    {
        // Reference from TankMovementSideways so that bullets only fire at 90 degree angles
        if(Input.GetKeyDown(KeyCode.Space) && tankHoldFire.turnLeft == false && tankHoldFire.turnRight == false)
        {
            // Vector3 and Quaternion variables here in order to make instantiated bullets not a child of the TankTurret gameobject
            // so that they dont move or rotate relative to the TankTurret, since the TankTurret can turn
            Vector3 bulletPosition = new Vector3(tankTurret.position.x, tankTurret.position.y, tankTurret.position.z);
            Quaternion bulletRotation = tankTurret.rotation;
            Instantiate(bullet, bulletPosition, bulletRotation);

            tankTurret.gameObject.GetComponent<AudioSource>().PlayOneShot(tankFireClip);

            totalTime = 0;
        }
    }
}
