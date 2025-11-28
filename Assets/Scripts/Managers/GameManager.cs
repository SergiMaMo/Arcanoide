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
    private string tiempoTemporizador = "00:00";
    private TextMeshProUGUI textoTemporizador;
    private int segundosTotales = 0;

    bool noContarTiempo = true;

    public IEnumerator Cronometro()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Temporizador");
        if (obj != null) textoTemporizador = obj.GetComponent<TextMeshProUGUI>();
        while (noContarTiempo)
        {
            

            if (obj == null)
            {
                obj = GameObject.FindGameObjectWithTag("Temporizador");
                if (obj != null) textoTemporizador = obj.GetComponent<TextMeshProUGUI>();
                
            }
            int minutos = segundosTotales / 60;
            int segundos = segundosTotales % 60;

            if (!tiempoTemporizador.Equals("00:00") && textoTemporizador.text.Equals("00:00"))
            {
                string[] tiempoSeparado = tiempoTemporizador.Split(':');
                int.TryParse(tiempoSeparado.GetValue(0).ToString(), out minutos);
                int.TryParse(tiempoSeparado.GetValue(1).ToString(), out segundos);
            }
            if (textoTemporizador != null)
            {
                textoTemporizador.text = $"{minutos:00}:{segundos:00}";
            }


            yield return new WaitForSeconds(1f);

            segundosTotales++;

            
            
        }
    }

    
    public void resetearVidasYPuntos()
    {
        this.vidas = 3;
        this.puntos = 0;
        this.segundosTotales = 0;
        this.tiempoTemporizador = "00:00";
        this.noContarTiempo = true;
    }
    public int getVidas()
    {
        return vidas;
    }
    public int getPuntos()
    {
        return puntos;
    }

    public string getTiempo()
    {
        return textoTemporizador.text;
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


        GameManager.Instance.StartCoroutine(Cronometro());

    }
    public void PerderVida()
    {
        vidas--;
        GameManager.Instance.EventManager.OnVidaCambiada.Invoke(this.vidas);
        if (vidas <= 0)
        {
            noContarTiempo = false;
            GameManager.Instance.StopCoroutine(Cronometro());
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
            

            if (GetNextSceneName().Equals("Victoria"))
            {
                noContarTiempo = false;
                GameManager.Instance.StopCoroutine(Cronometro());
            }
        }
    }

    private string GetNextSceneName()
    {
        int indexActual = SceneManager.GetActiveScene().buildIndex;
        int indexSiguiente = indexActual + 1;

        if (indexSiguiente >= SceneManager.sceneCountInBuildSettings) return null; // No hay más escenas

        string path = SceneUtility.GetScenePathByBuildIndex(indexSiguiente);
        string nombre = System.IO.Path.GetFileNameWithoutExtension(path);

        return nombre;
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
