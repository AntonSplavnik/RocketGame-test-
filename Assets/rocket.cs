using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour
{
    Rigidbody rigidBody;
    AudioSource sound;
    public float forwardForce = 20f;
    public float sideForce = 20f;


    void Start()
    {

        sound = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody>();
    }

    
    public void Update()
    {

        Thrust(forwardForce);
        Rotation(sideForce);

    }

    private void Thrust(float up)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            print("boost");
            rigidBody.AddRelativeForce(0, up, 0);

            if (!sound.isPlaying)
                sound.Play();
            //rigidBody.AddRelativeForce(Vector3.up);
        }
        else
            sound.Stop();
    }

    private void Rotation(float sideway)
    {
        rigidBody.freezeRotation = true;

        if (Input.GetKey(KeyCode.A))
        {
            print("left");
            transform.Rotate(sideway * Time.deltaTime, 0, 0);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            print("right");
            transform.Rotate(-sideway * Time.deltaTime, 0, 0);
        }

        rigidBody.freezeRotation = false;

    }

    
}
