using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaMovement : MonoBehaviour
{
    public Transform sea;
    float totalTime;
    float seaDrag = 0.5f;
    bool seaRises;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SeaRiseAndFall();
    }
    void SeaRiseAndFall()
    {
        // Swaps between moving the object up and down every 3 seconds, and mimics a weight drag effect
        // on the sea by reducing the speed at which it moves up or down as time accumulates
        if (totalTime > 3)
        {
            seaRises = true;
            seaDrag = 0.5f;
        }
        else if (totalTime < 0)
        {
            seaRises = false;
            seaDrag = 0.5f;
        }
        if (seaRises == false)
        {
            sea.Translate(new Vector3(0, -seaDrag, 0) * Time.deltaTime);
            totalTime += Time.deltaTime;
            seaDrag -= Time.deltaTime * 0.2f;
        }
        else if (seaRises == true)
        {
            sea.Translate(new Vector3(0, seaDrag, 0) * Time.deltaTime);
            totalTime -= Time.deltaTime;
            seaDrag -= Time.deltaTime * 0.2f;
        }
    }
}
