using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("Destroy", 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void Destroy()
    {
        Destroy(gameObject);
    }
}
