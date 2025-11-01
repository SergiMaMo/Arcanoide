using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinJuego : MonoBehaviour
{
    public void ResetearJuego()
    {
        SceneManager.LoadScene("Nivel1");
    }
}
