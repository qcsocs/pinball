using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScorer : MonoBehaviour {
    public int scores;
    private AudioSource audioSource;
    public GameObject effect;
    private GameObject explosion;
    private Color colour;
    
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        colour = GetComponent<SpriteRenderer>().color;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<ball>())
        {
            GameManager.score += scores;
            audioSource.Play();
            explosion = Instantiate(effect,GameObject.Find("Effects").transform);
            explosion.transform.position = collision.transform.position;
            ParticleSystem main =explosion.GetComponent<ParticleSystem>();
            main.startColor = colour;
        }
    }
}
