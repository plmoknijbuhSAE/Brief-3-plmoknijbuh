using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCamera : MonoBehaviour
{
    public Transform tankPosition;
    public Transform cameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowTankPosition();
    }

    void FollowTankPosition()
    {
        // Moves at the same speed as the tank. Not practical for any usage where the tank could move at different speeds
        // e.g. getting its collision blocked by an object and not moving but it does the job for the scope of this brief
        if (Input.GetKey(KeyCode.A))
        {
            cameraPosition.Translate(new Vector3(-5f, 0, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            cameraPosition.Translate(new Vector3(5f, 0, 0) * Time.deltaTime); 
        }
    }
}
