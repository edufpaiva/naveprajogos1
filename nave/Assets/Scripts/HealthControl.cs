using UnityEngine;
using System.Collections;

public class HealthControl : MonoBehaviour {
	public float  bounce, velocidadeMaxima;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.Instance.GetPlayerMorto() || GameManager.Instance.GetPause())
        {

            GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity.normalized * 0;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;



        }
        else if (GetComponent<Rigidbody2D>().velocity.magnitude < 1)
        {
            GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity.normalized * 5;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }
        Freio();
		

		
	}
	void FixedUpdate(){	
		
	}
	
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "UP" || col.gameObject.tag == "Player"){
			Destroy(gameObject);

		}
	}

	
	void Freio(){
		if(GetComponent<Rigidbody2D>().velocity.magnitude > velocidadeMaxima){
			
			GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity.normalized * velocidadeMaxima;
			
		}
		
	}

}
