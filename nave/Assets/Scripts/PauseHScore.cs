using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseHScore : MonoBehaviour
{
    private Text text;
    private int maiorPontos;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        
        maiorPontos = PlayerPrefs.GetInt("HScore");
        text.text = "High Score: " + maiorPontos.ToString();

    }
}
