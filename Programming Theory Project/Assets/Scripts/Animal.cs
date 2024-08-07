using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{

    public string sound { get; protected set; }
    public float jumpForce { get; protected set; }

    private Rigidbody myRb;
    [SerializeField] protected bool isOnAir;

    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public string Talk()
    {
        return sound;
    }

    public void Jump()
    {
        myRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isOnAir = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Floor":
            default:
                isOnAir = false;
                break;

        }
    }
}
