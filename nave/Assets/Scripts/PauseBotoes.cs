using UnityEngine;
using System.Collections;


public class PauseBotoes : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void RestartLevel()
    {
        GameManager.Instance.setPlayerVivo();
        Time.timeScale = 1;
        Application.LoadLevel(Application.loadedLevel);
        GameManager.Instance.SetPontos(0);

        if (GameManager.Instance.GetPause()) { GameManager.Instance.SetPause(); }
        
        




    }
    public void ExitGame() {

        Application.Quit();
    }

    public void HomeMenu(string nomeDaCena) {
        Time.timeScale = 1;
        GameManager.Instance.setPlayerVivo();
        UnityEngine.SceneManagement.SceneManager.LoadScene(nomeDaCena);
        if (GameManager.Instance.GetPause()) { GameManager.Instance.SetPause(); }
        GameManager.Instance.SetPontos(0);
    }
}
