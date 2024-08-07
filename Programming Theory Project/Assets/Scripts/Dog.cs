using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Dog : Animal
{
    private void Awake()
    {
        jumpForce = 30f;
        sounds = new string[4];
        sounds[0] = "Wuf";
        sounds[1] = "Bark";
        sounds[2] = "Growl";
        sounds[3] = "Bay";
    }
}
