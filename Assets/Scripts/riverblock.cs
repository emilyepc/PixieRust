using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class riverblock : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform river;
    public waterwheel wheel;
    public GameObject dryriver;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "box")
        {
            river.position=new Vector3(other.transform.position.x,river.position.y+.2f,river.position.z);
            wheel.on = false;
            dryriver.SetActive(false);
        }
    }
}
