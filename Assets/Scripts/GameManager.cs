using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static int score=0,ballCount=4;
    
    public GameObject ball, leftSavePillar, rightSavePillar;
    private GameObject newBall,left,right;
    private Level_Manager levelManager;
	// Use this for initialization
	void Start () {
        score = 0;
        ballCount = 4;
        StartGame();
        levelManager = FindObjectOfType<Level_Manager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ball>())
        {
            Invoke("StartGame", 1f);
        }
    }

    void StartGame()
    {
        if (newBall)
        {
            Destroy(newBall);
        }
        newBall=Instantiate(ball);
        newBall.transform.position = new Vector3(9.5f, -4.6f);
        ballCount -= 1;
        if (left)
        {
            Destroy(left);
        }
        left = Instantiate(leftSavePillar);
        left.transform.position = new Vector3(-6.76f, -15.56f);
        if (right)
        {
            Destroy(right);
        }
        right = Instantiate(rightSavePillar);
        right.transform.position = new Vector3(6.76f, -15.56f);
        if (ballCount < 0)
        {
            levelManager.LoadNextLevel();
        }
    }
}
