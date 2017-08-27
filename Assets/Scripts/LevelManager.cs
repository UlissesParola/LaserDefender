using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string scene)
	{
		SceneManager.LoadScene(scene);
	}	

	public void QuitGame()
	{
		Application.Quit();
	}	

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BricksDestroied()
    {
        LoadNextLevel();
    }          
}
