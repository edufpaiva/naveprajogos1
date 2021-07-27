﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseScore : MonoBehaviour
{
    private Text text;
    private int pontos = 0, maiorPontos;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        pontos = GameManager.Instance.GetPontos();
        maiorPontos = GameManager.Instance.GetMaiorPontuacao();
        text.text = "Score: " + pontos.ToString();

    }
}
