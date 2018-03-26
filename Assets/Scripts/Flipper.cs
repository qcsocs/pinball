using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour {
    public int isLeftFlipper;
    public float turningRate;
    private float rotation;
    private Rigidbody2D rigidBody;
    private HingeJoint2D hingeJoint;
    private JointMotor2D speed;
    private Vector3 originalPosition;
    private AudioSource audioSource;
    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
       hingeJoint = GetComponent<HingeJoint2D>();
        audioSource = GetComponent<AudioSource>();
        speed.maxMotorTorque = 1000;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            audioSource.Play();
        }

            LeftFlipper();
        hingeJoint.motor = speed;
        
    }




    void Flip()
    {
        
        
            hingeJoint.useMotor = true;
        
    }
    void LeftFlipper()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            speed.motorSpeed = -2000;
            Flip();
        }
        if (!Input.GetKey(KeyCode.LeftArrow))
        {
            speed.motorSpeed = 2000;

        }
    }
    void RightFlippers()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            speed.motorSpeed = 2000;
            Flip();
        }
        if (!Input.GetKey(KeyCode.RightArrow))
        {
            speed.motorSpeed = -2000;

        }
    }
}
