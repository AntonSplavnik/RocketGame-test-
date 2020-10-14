using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour
{
    Rigidbody rigidBody;
    AudioSource sound;
    [SerializeField] float forwardForce = 20f;
    [SerializeField] float sideForce = 20f;


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

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Start":
                print("Start");
                break;
            case "Obstacle":
                print("Obstacle");
                break;
        }
    }
    
    private void Thrust(float upForce)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            print("boost");
            rigidBody.AddRelativeForce(0, upForce, 0);

            if (!sound.isPlaying)
                sound.Play();
            //rigidBody.AddRelativeForce(Vector3.up);
        }
        else
            sound.Stop();
    }
    
    private void Rotation(float sidewayForce)
    {
        rigidBody.freezeRotation = true;

        if (Input.GetKey(KeyCode.D))
        {
            //print("left");
            transform.Rotate(sidewayForce * Time.deltaTime, 0, 0);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            //print("right");
            transform.Rotate(-sidewayForce * Time.deltaTime, 0, 0);
        }

        rigidBody.freezeRotation = false;

    }

    
}
