using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int vidas = 3;
    private void Update()
    {
        ComprobarVictoria();
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
    private void eliminarNodosInnecesarios()
    {
        foreach(Transform child in transform.GetChild(0))
        {
            if(child.childCount <= 0)
            {
                Destroy(child.gameObject);
            }
        }

    }

    private void ComprobarVictoria()
    {
        eliminarNodosInnecesarios();
        if (transform.GetChild(0).childCount <= 0)
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
