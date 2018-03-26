using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ranking : MonoBehaviour {
    const string name = "name";
    const string score = "score";
    private bool endsearch;   
    public static int rank;
    public InputField inputField;
    public GameObject display;
    // Use this for initialization
    void Start () {
        endsearch = false;
        CheckIfHaveRanking();
        print("Rank:" + rank);
        if (rank < 10)
        {
            display.SetActive(true);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public static string DisplayRankingName()
    {
        string[] text=new string[6];
        int i=1;
        while (i != 6)
        {
            text[i]= PlayerPrefs.GetString(i.ToString() + name);
            i += 1;
        }
        print("1." + text[1] + "2." + text[2] + "3." + text[3] + "4." + text[4] + "5." + text[5]);
        return "1. "+text[1] +"\n"+ "2. " + text[2] + "\n" + "3. " + text[3] + "\n" + "4. " + text[4] + "\n" + "5. " + text[5];
    }
    public static string DisplayRankingScore()
    {
        string[] scoresss = new string[6];
        int i = 1;
        while (i != 6)
        {
            scoresss[i] = PlayerPrefs.GetInt(i.ToString() + score).ToString();
            i += 1;
        }
        return scoresss[1] + "\n" + scoresss[2] + "\n" + scoresss[3] + "\n" + scoresss[4] + "\n" + scoresss[5];
    }

    public void CheckIfHaveRanking()
    {
        int j=6;

        while (j != 1 && endsearch==false)
        {
            if (GameManager.score > PlayerPrefs.GetInt((j - 1).ToString() + score))
            {
                j -= 1;
            }
            else
            {
                endsearch = true;
            }
        }
            
                if (j < 6)
                {
                    rank = j;
                    print("Has ranking");
                }
                else
                {
                    rank = 10;
                    print("Has no ranking");
                }
            
            
        
    }

    public void EstablishRanking()
    {
        int i = 5;
        if (rank < 10)
        {
            while (rank <= i)
            {
                PlayerPrefs.SetString((i + 1).ToString() + name, PlayerPrefs.GetString(i.ToString() + name));
                PlayerPrefs.SetInt((i + 1).ToString() + score, PlayerPrefs.GetInt(i.ToString() + score));
                i -= 1;
            }
            PlayerPrefs.SetString(rank.ToString() + name, inputField.text);
            PlayerPrefs.SetInt(rank.ToString() + score, GameManager.score);
        }
    }
}
