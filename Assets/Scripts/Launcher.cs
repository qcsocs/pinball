using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour {
    private float yPos;
    private bool charging,launching;
    public PhysicsMaterial2D physics;
    private GameObject ball;
    private Vector3 offset;
	// Use this for initialization
	void Start () {
        yPos = transform.position.y;

	}
	
	// Update is called once per frame
	void Update () {
        ball = FindObjectOfType<ball>().gameObject;
        yPos = Mathf.Clamp(yPos,-18f, -12f);
        if (Input.GetKey(KeyCode.Space))
        {
            charging = true;
            yPos -= 0.1f;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
           
            
            charging = false;
            launching = true;
        }
        if (launching)
        {

            if (Mathf.Abs(ball.transform.position.y - transform.position.y) < 8 && Mathf.Abs(ball.transform.position.x - transform.position.x) < 1)
            {
                ball.GetComponent<ball>().LaunchBall();
                
               
                ball.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 100f, 0);
            }
           
            yPos += 0.5f;
            if (yPos > -12f)
            {
                launching = false;
            }
        }
        else
        {
        }
       
        transform.position = new Vector3(transform.position.x, yPos);
	}
}
