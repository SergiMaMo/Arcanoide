using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointController : MonoBehaviour
{

    [SerializeField] private TMP_Text puntuacion;

    private void Start()
    {
        GameManager.Instance.EventManager.OnPuntosCambiados.AddListener(ActualizarUI);
        GameManager.Instance.GanarPuntos(0);
    }

    private void ActualizarUI(int puntos)
    {
        puntuacion.text = puntos.ToString();
    }
}
