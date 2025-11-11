using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladrillo : MonoBehaviour
{
    public int Vida;
    public int puntos;
    public GameObject PowerUp;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BolaPrincipal"))
        {
            GameManager gameManager = GameObject.FindAnyObjectByType<GameManager>();
            gameManager.puntos += puntos;
            Vida--;
            if(Vida <= 0)
            {
                if(PowerUp != null)
                {
                    Instantiate(PowerUp,transform.position,Quaternion.identity);
                }
                Destroy(this.gameObject);
            }
        }
    }

}
