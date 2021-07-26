using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    private bool mRestart;
    private int pontos, maiorPontuacao;
    private bool playerMorto = false, pause = false, pararTextura = false;
    public GameObject bonusVida;

    private bool jaGanhouVida = false;

    private bool mudo = false;

    private bool creditoAtivo;
    void Awake() {
        DontDestroyOnLoad(gameObject);

        if(Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start() {
        this.pontos = 0;
        maiorPontuacao = PlayerPrefs.GetInt("HScore", 0);

    }

    // Update is called once per frame
    void Update() {
        // print(Time.fixedTime);

        BonusVida();


        if(Input.GetKeyDown(KeyCode.Q)) {
            playerMorto = false;
            Time.timeScale = 1;
            Application.LoadLevel(Application.loadedLevel);


        }
        if(Input.GetKeyDown(KeyCode.R)) {
            PlayerPrefs.SetInt("HScore", 0);
            PlayerPrefs.Save();

        }


        if(Input.GetKeyDown(KeyCode.G)) {
            PlayerPrefs.SetInt("HScore", 112);
            PlayerPrefs.Save();

        }


    }

    public void RestartLevel() {
        playerMorto = false;
        Time.timeScale = 1;
        pontos = 0;
        Application.LoadLevel(Application.loadedLevel);
        //SceneManager.LoadScene(0);

    }

    public void SetPontos(int pontuacao) {
        this.pontos += pontuacao;
        if(pontuacao == 0) { this.pontos = 0; }
        jaGanhouVida = false;


    }

    public int GetPontos() {

        return this.pontos;
    }

    public int GetMaiorPontuacao() {
        return maiorPontuacao;
    }

    public void SetMaiorPontuacao() {
        if(maiorPontuacao < pontos) {

            maiorPontuacao = pontos;
        }

    }

    public void SetMorte() {

        this.playerMorto = true;
        SalvaHScore();
        //Time.timeScale = 0;
    }

    public bool GetPlayerMorto() { return this.playerMorto; }
    public void setPlayerVivo() { playerMorto = false; }
    public bool GetPause() { return this.pararTextura; }
    public void SetPause() { pararTextura = !pararTextura; }

    void BonusVida() {


        if(!jaGanhouVida) {
            if(pontos % 10 == 0 && pontos > 1) {

                float i = Random.Range(-1f, 2f);

                Instantiate(bonusVida, new Vector3(i, 13, -1), Quaternion.identity);
                jaGanhouVida = true;
            }



        }


    }

    void SalvaHScore() {
        if(PlayerPrefs.GetInt("HScore") <= maiorPontuacao) {
            PlayerPrefs.SetInt("HScore", maiorPontuacao);
            PlayerPrefs.Save();
        }

    }

    public bool GetMudo() {
        return this.mudo;
    }

    public void SetMudo() {
        this.mudo = !this.mudo;
    }

    public void SetCreditoAtivo() {
        this.creditoAtivo = !this.creditoAtivo;
    }

    public bool GetCreditoAtivo() {
        return this.creditoAtivo;
    }

}