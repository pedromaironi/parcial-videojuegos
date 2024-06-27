using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class impares : MonoBehaviour
{


    private int ValorMinimo = 0;
    private int ValorMaximo = 100;

    public Text valor;

    void Start()
    {
        MostrarImpares(1, 1000);
        valor.text = "";
    }

    public void MostrarImpares(int min, int max)
    {
        string texto = "";
        for (int i = min; i <= max; i++)
        {
            if (EsImpar(i) && (i < ValorMinimo || i > ValorMaximo))
            {
                texto += i.ToString() + " ";
            }
        }

        valor.text = texto;
        UnityEngine.Debug.Log("Texto mostrado: " + texto);
    }

    bool EsImpar(int num)
    {
        return num % 2 != 0;
    }
}
