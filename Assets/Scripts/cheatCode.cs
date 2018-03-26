using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class cheatCode : MonoBehaviour {
    private InputField inputField;
    const string name = "name";
    const string score = "score";
    // Use this for initialization
    void Start () {
        inputField = GetComponent<InputField>();
	}
	
	// Update is called once per frame
	void Update () {
        if (inputField.text == "reset123")
        {
            resetRanking();
        }
	}
    void resetRanking()
    {
        int i=1;
        while (i != 6)
        {
            PlayerPrefs.SetString(i.ToString()+name, null);
            PlayerPrefs.SetInt(i.ToString() + score, 0);
            i += 1;
        }
    }
}
