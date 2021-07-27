using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
    private Animator mAnimator;
    private bool pause = false;
    public GameObject menuPause, HUD;
	// Use this for initialization
	void Start () {
        mAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (GameManager.Instance.GetPlayerMorto()) {
            Destroy(gameObject);


        }
	}


    public void Pausar() {
        pause = !pause;
        if (pause)
           
        {
            
            
            mAnimator.SetBool("pause", pause);
            menuPause.SetActive(true);
            HUD.SetActive(false);
            //Time.timeScale = 0;
            GameManager.Instance.SetPause();

        }
        else {
            //Time.timeScale = 1;
            
            mAnimator.SetBool("pause", pause);
            menuPause.SetActive(false);
            HUD.SetActive(true);
            GameManager.Instance.SetPause();
        }

    }

    
}
