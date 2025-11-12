using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Ladrillo : MonoBehaviour
{
    public LadrilloData data;
    public GameObject PowerUp;

    private int vidas;
    private int puntos;
    private Color color;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        vidas = data.Vida;
        puntos = data.Puntos;
        spriteRenderer.color = data.ColorInicial;


    }
    private void OnDestroy()
    {
        GameManager.Instance.ComprobarVictoria();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BolaPrincipal"))
        {
            
            
            vidas--;
            if(vidas <= 0)
            {
                if(PowerUp != null)
                {
                    GameManager.Instance.GanarPuntos(puntos);
                    GameManager.Instance.actualizarPuntos();
                    Instantiate(PowerUp,transform.position,Quaternion.identity);
                }
                Destroy(this.gameObject);
                
            }
        }
    }

}
