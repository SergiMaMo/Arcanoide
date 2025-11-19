using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LiveController : MonoBehaviour
{
    [SerializeField] private GameObject ContadorDeVida3;
    [SerializeField] private GameObject ContadorDeVida2;

    private void Start()
    {
        GameManager.Instance.EventManager.OnVidaCambiada.AddListener(ActualizarUI);
        GameManager.Instance.ActualizarVidas();
    }

    private void ActualizarUI(int vidas)
    {
        SpriteRenderer spriteRendererVida3 = ContadorDeVida3.GetComponent<SpriteRenderer>();
        SpriteRenderer spriteRendererVida2 = ContadorDeVida2.GetComponent<SpriteRenderer>();
        switch (vidas)
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
}
