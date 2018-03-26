using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savePillar : MonoBehaviour {

    private float yPos;
    private bool charging=true, launching;
    public PhysicsMaterial2D physics;
    public GameObject ball;
    private Vector3 offset;
    // Use this for initialization
    void Start()
    {
        yPos = transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        ball = FindObjectOfType<ball>().gameObject;
        yPos = Mathf.Clamp(yPos,-16.46f , -15.56f);
        if (launching)
        {
            Launch();
            transform.position = new Vector3(transform.position.x,yPos);
        }
        if(!charging)
        {
            Destroy(gameObject);
        }
        print(charging);
       
        

            
        
      

        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<ball>())
        {
            Invoke("Inititate", 2f);
        }
    }

    void Inititate()
    {
        launching = true;
        
    }

    void Launch()
    {
        if (charging)
        {
            if (yPos > -16.46f)
            {
                yPos -= 0.1f;
            }
            else
            {
                if (ball.transform.position.y - transform.position.y < 8 && ball.transform.position.x - transform.position.x < 4)
                {
                    ball.GetComponent<ball>().LaunchBall();
                    ball.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 200f, 0);
                }


                yPos += 0.7f;
                charging = false;
                if (yPos >= -15.7f)
                {
                    
                    charging = false;
                    
                }
            }
        }
    }
   void Destroys()
    {
        Destroy(gameObject);
    }
}
