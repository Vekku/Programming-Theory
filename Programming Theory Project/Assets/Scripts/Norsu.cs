using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Norsu : Animal
{

    private CameraShake cShake;


    private void Awake()
    {
        jumpForce = 1500f;
        if (cShake == null)
        {
            cShake = GameObject.Find("Main Camera").GetComponent<CameraShake>();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Floor":
            default:
                if (isOnAir)
                {
                    // Shake
                    cShake.ShakeCamera();
                }
                break;
        }
    }
}
