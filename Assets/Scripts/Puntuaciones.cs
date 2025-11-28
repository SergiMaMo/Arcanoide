using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Puntuaciones : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject puntosFinales = GameObject.FindGameObjectWithTag("Puntos");
        GameObject tiempoFinal = GameObject.FindGameObjectWithTag("Temporizador");

        TextMeshProUGUI textoPuntosFinales = puntosFinales.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI textoTiempoFinal = tiempoFinal.GetComponent<TextMeshProUGUI>();

        textoPuntosFinales.text = GameManager.Instance.getPuntos().ToString();
        textoTiempoFinal.text = GameManager.Instance.getTiempo().ToString();
    }


}
