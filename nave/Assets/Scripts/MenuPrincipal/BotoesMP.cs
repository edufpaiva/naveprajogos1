using UnityEngine;
using System.Collections;

public class BotoesMP : MonoBehaviour {
    private bool som, creditoAtivado;
    public GameObject creditos;
    private Animator mAnimator;


    void Awake()
    {
        mAnimator = GetComponent<Animator>();
    }
    // Use this for initialization
    void Start () {

        
        
        if (GameManager.Instance.GetMudo())
        {
            mAnimator.SetBool("SomLigado", false);

        }
        else {
            mAnimator.SetBool("SomLigado", true);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AtivaSom() {
        
        GameManager.Instance.SetMudo();

        mAnimator.SetBool("SomLigado", !GameManager.Instance.GetMudo());




    }



    public void AtivaCredito() {

        creditos.SetActive(GameManager.Instance.GetCreditoAtivo());
        GameManager.Instance.SetCreditoAtivo();

    }
}
