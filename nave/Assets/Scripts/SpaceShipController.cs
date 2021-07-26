using UnityEngine;
using System.Collections;


public class SpaceShipController : MonoBehaviour
{
    public float velocity, life, bonusVida;
    private Animator mAnimator;
    public Animator lifeAnimator;
    private float direcao;
    public GameObject menuPause;

    public AudioSource explosionSFX, hitSFX, bonusVidaSFX;
    private bool playExplosionSFX = true;

    void Awake()
    {
        mAnimator = GetComponent<Animator>();
    }

    void Start()
    {
        lifeAnimator.SetInteger("Vida", 10);
        print(GameManager.Instance.GetMudo());
        Time.timeScale = 1;
        
    }

    void Update()
    {
        if (GameManager.Instance.GetPlayerMorto() || GameManager.Instance.GetPause())
        {
            return;

        }
        else {

            if (lifeAnimator.GetInteger("Vida") == 0) {
                LifeChange();



            }


            //LifeChange();
            transform.position = new Vector3(transform.position.x, -3, transform.position.z);



            if (life <= 0)
            {
                //lifeAnimator.SetInteger("Life", 12);
                mAnimator.SetBool("Morreu", true);
                if (playExplosionSFX) {

                    if (!GameManager.Instance.GetMudo()) { explosionSFX.Play(); }
                    


                    playExplosionSFX = false;
                }
                
                Time.timeScale = 0.3f;




                Invoke("Morreu", 0.5f);

            }



            if (Input.GetKey(KeyCode.LeftArrow) || direcao == -1)
            {
                if (mAnimator.GetBool("TurnRight")) { mAnimator.SetBool("TurnRight", false); }

                mAnimator.SetBool("TurnLeft", true);
                GetComponent<Rigidbody2D>().velocity = Vector2.left * velocity;
            }
            else if (Input.GetKey(KeyCode.RightArrow) || direcao == 1)
            {
                if (mAnimator.GetBool("TurnLeft")) { mAnimator.SetBool("TurnLeft", false); }
                mAnimator.SetBool("TurnRight", true);
                GetComponent<Rigidbody2D>().velocity = Vector2.right * velocity;
            }
            else {
                mAnimator.SetBool("TurnRight", false);
                mAnimator.SetBool("TurnLeft", false);
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }

        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "BonusVida")
        {

            life += bonusVida;
            
            //print (life);
            LifeChange();

            if (!GameManager.Instance.GetMudo()) { bonusVidaSFX.Play(); }
            
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Death")
        {
            life -= 10;
            if (!GameManager.Instance.GetMudo()) { hitSFX.Play(); }
             
            mAnimator.SetTrigger("Hit");
            LifeChange();


        }

        if (col.gameObject.tag == "WallR")
        {
            life -= 30;
            if (!GameManager.Instance.GetMudo())
            {
                hitSFX.Play();
            }
            mAnimator.SetTrigger("Hit");
            //GetComponent<Rigidbody2D> ().velocity = Vector2.left * (velocity/2);
            LifeChange();

        }

        if (col.gameObject.tag == "WallL")
        {
            life -= 30;
            mAnimator.SetTrigger("Hit");
            //GetComponent<Rigidbody2D> ().velocity = Vector2.right * (velocity/2);
            LifeChange();
            if (!GameManager.Instance.GetMudo())
            {
                hitSFX.Play();
            }

        }


    }




    void OnCollisionStay2D(Collision2D col)
    {

        //if (col.gameObject.tag == "WallL" || col.gameObject.tag == "WallR")
       // {
         //   life -= 1;
            //mAnimator.SetTrigger("Hit");
         //   LifeChange();

       // }

    }

    void Reload()
    {
        Debug.Log("lalalala");
        Application.LoadLevel(Application.loadedLevel);

    }

    void LifeChange()
    {

        if (life > 99)
        {
            lifeAnimator.SetInteger("Vida", 10);
        }
        else if (life < 99 && life > 89)
        {
            lifeAnimator.SetInteger("Vida", 9);

        }
        else if (life < 89 && life > 79)
        {
            lifeAnimator.SetInteger("Vida", 8);

        }
        else if (life < 79 && life > 69)
        {
            lifeAnimator.SetInteger("Vida", 7);

        }
        else if (life < 69 && life > 59)
        {
            lifeAnimator.SetInteger("Vida", 6);

        }
        else if (life < 59 && life > 49)
        {
            lifeAnimator.SetInteger("Vida", 5);

        }
        else if (life < 49 && life > 39)
        {
            lifeAnimator.SetInteger("Vida", 4);

        }
        else if (life < 39 && life > 29)
        {
            lifeAnimator.SetInteger("Vida", 3);

        }
        else if (life < 29 && life > 19)
        {
            lifeAnimator.SetInteger("Vida", 2);

        }
        else if (life < 19 && life > 1)
        {
            lifeAnimator.SetInteger("Vida", 1);

        }
        else if (life < 1)
        {
            lifeAnimator.SetInteger("Vida", 0);

        }



    }

    public void SetDirecao(float f)
    {
        if (f == 1)
        {
            direcao = 1;
        }
        else if (f == -1)
        {
            direcao = -1;
        }
        else {
            direcao = 0;

        }

    }

    void Morreu()
    {
        menuPause.SetActive(true);

        GameManager.Instance.SetMorte();
        Destroy(gameObject);

    }

}
