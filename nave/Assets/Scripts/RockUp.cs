using UnityEngine;
using System.Collections;

public class RockUp : MonoBehaviour {
	public float altura, velocidadePedra, bounce, gravidade, velocidadeMaxima;
	private Vector3 temp;
	public int score = 0;
	public GameObject bonusVida;
	private bool jaGanhouVida = false;
	public float vidaIntervalo;




	// Use this for initialization
	void Start () {
		temp.y = altura;
		temp.z = 0;


	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.Instance.GetPlayerMorto() || GameManager.Instance.GetPause())
        {

            GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity.normalized * 0;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;



        } else if (GetComponent<Rigidbody2D>().velocity.magnitude < 1) {
            GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity.normalized * 5;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }

        Freio();

        

    }
	void FixedUpdate(){
	

	}
	
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "UP"){
		temp.x = Random.Range(-4f, 4f);	

			transform.position = temp;
            GameManager.Instance.SetPontos(1);
            GameManager.Instance.SetMaiorPontuacao();
           
			//print (score);
		}
	}



	void Freio(){
		if(GetComponent<Rigidbody2D>().velocity.magnitude > velocidadeMaxima){

			GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity.normalized * velocidadeMaxima;

		}



	}
	




}
