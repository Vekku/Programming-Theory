using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Cat : Animal
{
    private void Awake()
    {
        jumpForce = 20f;
        sounds = new string[4];
        sounds[0] = "Mew";
        sounds[1] = "Purr";
        sounds[2] = "Hiss";
        sounds[3] = "Growl";
    }
}
