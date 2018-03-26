using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Manager : MonoBehaviour {

	public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void Quit()
    {
		#if (UNITY_EDITOR || DEVELOPMENT_BUILD)
		Debug.Log(this.name+" : "+this.GetType()+" : "+System.Reflection.MethodBase.GetCurrentMethod().Name); 
		#endif
		#if (UNITY_EDITOR)
		UnityEditor.EditorApplication.isPlaying = false;
		#elif (UNITY_STANDALONE) 
		Application.Quit();
		#elif (UNITY_WEBGL)
		Application.OpenURL("https://opendays.qcsocs.tk/");
		#endif
    }
}
