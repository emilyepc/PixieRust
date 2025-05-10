using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RailCartController : MonoBehaviour
{
    [Header("References")]
    public GameObject RailGate;
    public GameObject StaticCart;
    public GameObject MovingCart;
    public GameObject text;

    void Update()
    {

        if (RailGate.activeSelf)
        {

            StaticCart.SetActive(true);
            MovingCart.SetActive(false);
            text.SetActive(false);
        }
        else
        {
            StaticCart.SetActive(false);
            MovingCart.SetActive(true);
            text.SetActive(true);
        }
    }
}
