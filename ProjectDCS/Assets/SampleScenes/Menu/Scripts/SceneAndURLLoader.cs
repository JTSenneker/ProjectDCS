using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAndURLLoader : MonoBehaviour
{
    private PauseMenu2 m_PauseMenu2;


    private void Awake ()
    {
        m_PauseMenu2 = GetComponentInChildren <PauseMenu2> ();
    }


    public void SceneLoad(string sceneName)
	{
		//PauseMenu2 PauseMenu2 = (PauseMenu2)FindObjectOfType(typeof(PauseMenu2));
		m_PauseMenu2.MenuOff ();
		SceneManager.LoadScene(sceneName);
	}


	public void LoadURL(string url)
	{
		Application.OpenURL(url);
	}
}

