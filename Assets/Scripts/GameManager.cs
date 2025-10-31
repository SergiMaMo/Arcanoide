using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int vidas = 3;

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

    private void ResetearPalaYBola()
    {
        FindObjectOfType<Pala>().ResetearAPosicionInicial();
        FindObjectOfType<Bola>().ResetearAPosicionInicial();
    }
}
