using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {
    public PhysicsMaterial2D physics;
    public float maxSpeed;
    private float x, y,velocityy;
    private Rigidbody2D rigidBody;
    public  bool launching;
    private AudioSource audioSource;
	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (rigidBody.velocity.x > maxSpeed)
        {
            rigidBody.velocity = new Vector3(maxSpeed, rigidBody.velocity.y);
        }
        if (rigidBody.velocity.x < -maxSpeed)
        {
            rigidBody.velocity = new Vector3(-maxSpeed, rigidBody.velocity.y);
        }
        if (rigidBody.velocity.y > maxSpeed)
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x,maxSpeed );
        }
        if (rigidBody.velocity.y < -maxSpeed)
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, -maxSpeed);
        }
        
        if (launching)
        {
            maxSpeed = 40;
            Invoke("cancelLaunching", 1f);
        }





    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        x = Random.Range(-0.5f, 0.5f)+rigidBody.velocity.x;
        y = Random.Range(-0.5f, 0.5f) + rigidBody.velocity.y;
        rigidBody.velocity = new Vector3(x, y, 0);
        audioSource.Play();
    }
    void cancelLaunching()
    {
        launching = false;
        maxSpeed = 24;
    }
    public  void LaunchBall()
    {
        launching = true;
    }
}
