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
            ResetearPalaYBola();
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
