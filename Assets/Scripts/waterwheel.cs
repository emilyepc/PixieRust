using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterwheel : MonoBehaviour
{
    // Start is called before the first frame update
    public float wheelspeed=1;
    public bool on;
    public int direction;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (on)
        {
            transform.Rotate(0, wheelspeed * direction, 0);
        }
    }
}
