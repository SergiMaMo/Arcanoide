using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public EventManager EventManager = new EventManager();
    public static GameManager Instance;
    private int vidas = 3;
    private int puntos = 0;

    public void resetearVidasYPuntos()
    {
        this.vidas = 3;
        this.puntos = 0;
    }
    public int getVidas()
    {
        return vidas;
    }
    public int getPuntos()
    {
        return puntos;
    }

    public void GanarPuntos(int puntos)
    {
        this.puntos += puntos;
        GameManager.Instance.EventManager.OnPuntosCambiados.Invoke(this.puntos);
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void PerderVida()
    {
        vidas--;
        GameManager.Instance.EventManager.OnVidaCambiada.Invoke(this.vidas);
        if (vidas <= 0)
        {
            SceneManager.LoadScene("FinalDelJuego");
        }
        else
        {
            ResetearPalaYBola();
        }
    }

    public void GanarVida()
    {
        vidas++;
        GameManager.Instance.EventManager.OnVidaCambiada.Invoke(this.vidas);
    }

    public void ActualizarVidas()
    {
        GameManager.Instance.EventManager.OnVidaCambiada.Invoke(this.vidas);
    }

    public void ComprobarVictoria()
    {

        GameObject[] ListaLadrillosRestantes = GameObject.FindGameObjectsWithTag("Ladrillo");
        if (ListaLadrillosRestantes.Length <= 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


    private void ResetearPalaYBola()
    {
        GameObject[] PowerUpsEnVuelo = GameObject.FindGameObjectsWithTag("PowerUp");

        foreach (GameObject PowerUpEnVuelo in PowerUpsEnVuelo)
        {
            Destroy(PowerUpEnVuelo);
        }
        FindObjectOfType<Pala>().ResetearAPosicionInicial();
        FindObjectOfType<Bola>().ResetearAPosicionInicial();
    }
}
