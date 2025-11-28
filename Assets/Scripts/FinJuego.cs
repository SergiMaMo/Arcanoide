using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinJuego : MonoBehaviour
{
    public void ResetearJuego()
    {
        GameManager.Instance.resetearVidasYPuntos();
        SceneManager.LoadScene("Nivel1");
        GameManager.Instance.StartCoroutine(GameManager.Instance.Cronometro());
    }
}
