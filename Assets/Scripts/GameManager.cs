using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    private int vidas = 3;
    private int puntos = 0 ;

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
    }
    private void Awake()
    {
        if(Instance != null && Instance != this)
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

        if(vidas <= 0)
        {
            SceneManager.LoadScene("FinalDelJuego");
        }
        else
        {
            cambiar_vida_contadores(vidas);
            ResetearPalaYBola();
        }
    }

    public void GanarVida()
    {
        vidas++;
        cambiar_vida_contadores(vidas);
    }
    public void actualizarPuntos()
    {
        TMP_Text textComponent;
        GameObject ContadorPuntos = GameObject.FindGameObjectWithTag("Puntos");
        textComponent = ContadorPuntos.GetComponent<TMP_Text>();
        textComponent.text = puntos.ToString();
    }

    private void cambiar_vida_contadores(int vida)
    {
        GameObject ContadorDeVida3 = GameObject.FindGameObjectWithTag("Vida3");
        GameObject ContadorDeVida2 = GameObject.FindGameObjectWithTag("Vida2");

        SpriteRenderer spriteRendererVida3 = ContadorDeVida3.GetComponent<SpriteRenderer>();
        SpriteRenderer spriteRendererVida2 = ContadorDeVida2.GetComponent<SpriteRenderer>();
        switch (vida)
        {
            case 3:
                spriteRendererVida3.color = Color.white;
                spriteRendererVida2.color = Color.white;
                break;
            case 2:
                spriteRendererVida3.color = Color.black;
                spriteRendererVida2.color = Color.white;
                break;
            case 1:
                spriteRendererVida3.color = Color.black;
                spriteRendererVida2.color = Color.black;
                break;
        }
    }
    

    public void ComprobarVictoria()
    {
        
        GameObject[] ListaLadrillosRestantes = GameObject.FindGameObjectsWithTag("Ladrillo");
        if (ListaLadrillosRestantes.Length <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void ResetearPalaYBola()
    {
        GameObject[] PowerUpsEnVuelo = GameObject.FindGameObjectsWithTag("PowerUp");

        foreach(GameObject PowerUpEnVuelo in PowerUpsEnVuelo)
        {
            Destroy(PowerUpEnVuelo);
        }
        FindObjectOfType<Pala>().ResetearAPosicionInicial();
        FindObjectOfType<Bola>().ResetearAPosicionInicial();
    }
}
