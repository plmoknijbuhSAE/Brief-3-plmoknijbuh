using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplosion : MonoBehaviour
{
    float totalTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Ensures it deletes itself after playing the explosion effect
        totalTime += Time.deltaTime;
        
        if(totalTime > 2)
        {
            Destroy(gameObject);
        }
    }
}
