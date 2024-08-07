using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// INHERITANCE
public class Norsu : Animal
{

    private CameraShake cShake;


    private void Awake()
    {
        jumpForce = 1500f;
        sounds = new string[1];
        sounds[0] = "Trumpet";
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

    // POLYMORPHISM
    public override void Talk()
    {
        ShowBubble(true);
        string sound = sounds[0];
        base.speechBubbleCanvas.transform.Find("Sound Text").GetComponent<TextMeshProUGUI>().text = sound;
        cShake.ShakeCamera(0.1f);
        StartCoroutine(CloseBubble());
    }
}
