using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovementSideways : MonoBehaviour
{
    public Transform tankMoveSide;
    public Transform tankTurret;
    public Transform tankChassis;

    public AudioSource tankSound;
    public AudioClip tankIdle;
    public AudioClip tankMove;
    public Rigidbody rb;

    float totalTime;
    float timeForFlip;
    public bool turnLeft;
    public bool turnRight;
    bool turnChassisLeft;
    bool turnChassisRight;
    bool lookingLeft;
    bool lookingRight;
    bool slowDown;
    float slowTime;

    // Start is called before the first frame update
    void Start()
    {
        lookingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (tankSound.isPlaying == false)
        {
            tankSound.Play();
        }

        TankMovementLeftRight();
        TankTurretLeftRight();
        TankJump();
    }

    void TankMovementLeftRight()
    {
        // Moves the tank at a constant speed as dictated by Time.deltaTime relative to the global axis'
        if (Input.GetKeyDown(KeyCode.A) && lookingRight == true)
        {
            turnChassisLeft = true;
            lookingRight = false;
        }
        else if(Input.GetKey(KeyCode.A) && lookingLeft == true)
        {
            tankMoveSide.Translate(new Vector3(-5f, 0, 0) * Time.deltaTime, Space.World);
            tankSound.clip = tankMove;
        }
        if(Input.GetKeyUp(KeyCode.A) && lookingLeft == true)
        {
            slowTime = 3;
            slowDown = true;
        }

        if(Input.GetKeyDown(KeyCode.D) && lookingLeft == true)
        {
            turnChassisRight = true;
            lookingLeft = false;
        }
        else if (Input.GetKey(KeyCode.D) && lookingRight == true)
        {
            tankMoveSide.Translate(new Vector3(5f, 0, 0) * Time.deltaTime, Space.World);
            tankSound.clip = tankMove;
        }
        if(Input.GetKeyUp(KeyCode.D) && lookingRight == true)
        {
            slowTime = 3;
            slowDown = true;
        }

        if(slowDown == true)
        {
            slowTime -= Time.deltaTime * 15;
            if(lookingLeft == true)
            {
                tankMoveSide.Translate(new Vector3(-slowTime, 0, 0) * Time.deltaTime, Space.World);
            }
            else if(lookingRight == true)
            {
                tankMoveSide.Translate(new Vector3(slowTime, 0, 0) * Time.deltaTime, Space.World);
            }
            if(slowTime <= 0 || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
            {
                slowDown = false;
            }
        }

        if(Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            tankSound.clip = tankIdle;
        }
 
        if (turnChassisLeft == true)
        {
            timeForFlip += Time.deltaTime * 1.3f;
            tankChassis.Rotate(Vector3.up, 180 * Time.deltaTime * 1.3f);

            if (timeForFlip > 1)
            {                
                timeForFlip = 0;
                lookingLeft = true;
                lookingRight = false;
                turnChassisLeft = false;
            }
        }
        if (turnChassisRight == true)
        {
            timeForFlip += Time.deltaTime * 1.3f;
            tankChassis.Rotate(Vector3.down, 180 * Time.deltaTime * 1.3f);

            if(timeForFlip > 1)
            {               
                timeForFlip = 0;
                lookingRight = true;
                lookingLeft = false;
                turnChassisRight = false;
            }
        }
    }

    void TankTurretLeftRight()
    {
        // Checks for whether the barrel can turn
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tankTurret.rotation.eulerAngles.y != 270 && turnRight == false)
        {
            turnLeft = true;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow) && tankTurret.rotation.eulerAngles.y != 90 && turnLeft == false)
        {
            turnRight = true;
        }

        // Turns the barrel at a set speed for a set time with constraints on when it can no longer turn
        if (turnLeft == true && tankTurret.rotation.eulerAngles.y <= 270 && totalTime < 1)
        {
            totalTime += Time.deltaTime * 2.5f;
            tankTurret.Rotate(Vector3.up, 90 * Time.deltaTime * 2.5f);
        }
        else if(turnRight == false)
        {
            turnLeft = false;
            totalTime = 0;
        }

        if (turnRight == true && tankTurret.rotation.eulerAngles.y >= 90 && totalTime < 1)
        {
            totalTime += Time.deltaTime * 2.5f;
            tankTurret.Rotate(Vector3.down, 90 * Time.deltaTime * 2.5f);
        }
        else if(turnLeft == false)
        {
            turnRight = false;
            totalTime = 0;
        }

        // Ensures that minute errors on exact scales of rotation do not exponentially compound on themselves with each rotation.
        // Sets rotation when barrel is not turning to a flat number based on the 3 angles I have set
        if(turnLeft == false && turnRight == false)
        {
            if (tankTurret.rotation.eulerAngles.y >= 260 && tankTurret.rotation.eulerAngles.y <= 280)
            {
                tankTurret.rotation = Quaternion.Euler(0, 270, 0);
            }
            else if (tankTurret.rotation.eulerAngles.y >= 170 && tankTurret.rotation.eulerAngles.y <= 190)
            {
                tankTurret.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if(tankTurret.rotation.eulerAngles.y >= 80 && tankTurret.rotation.eulerAngles.y <= 100)
            {
                tankTurret.rotation = Quaternion.Euler(0, 90, 0);
            }
        }
    }

    void TankJump()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
            Debug.Log("YES");
        }
    }
}
