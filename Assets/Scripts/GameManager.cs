using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int vidas = 3;
    public int puntos = 0 ;
    private void Update()
    {
        ComprobarVictoria();
        actualizarPuntos();
    }
    public void PerderVida()
    {
        vidas--;

        if(vidas <= 0)
        {
            SceneManager.LoadScene("FinalDelJuego");
        }
        else
        {
            bajar_vida_contadores(vidas);
            ResetearPalaYBola();
        }
    }

    private void actualizarPuntos()
    {
        TMP_Text textComponent;
        GameObject ContadorPuntos = GameObject.FindGameObjectWithTag("Puntos");
        textComponent = ContadorPuntos.GetComponent<TMP_Text>();
        textComponent.text = puntos.ToString();
    }

    private void bajar_vida_contadores(int vida)
    {
        GameObject ContadorDeVida3 = GameObject.FindGameObjectWithTag("Vida3");
        GameObject ContadorDeVida2 = GameObject.FindGameObjectWithTag("Vida2");

        if (vida < 3)
        {
            SpriteRenderer spriteRenderer = ContadorDeVida3.GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.black;
        }
        if (vida < 2)
        {
            SpriteRenderer spriteRenderer = ContadorDeVida2.GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.black;
        }
    }
    

    private void ComprobarVictoria()
    {
        
        GameObject[] ListaLadrillosRestantes = GameObject.FindGameObjectsWithTag("Ladrillo");
        if (ListaLadrillosRestantes.Length <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void ResetearPalaYBola()
    {
        FindObjectOfType<Pala>().ResetearAPosicionInicial();
        FindObjectOfType<Bola>().ResetearAPosicionInicial();
    }
}
