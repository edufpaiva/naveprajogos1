using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	//public Animator cometa1, cometa2;
	// Use this for initialization
	void Start(){
		//cometa1.SetBool("turnLeft", false);
	}

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();

        }

    }
	public void CarregarCena(string nomeDaCena){
		UnityEngine.SceneManagement.SceneManager.LoadScene (nomeDaCena);
	}
}
