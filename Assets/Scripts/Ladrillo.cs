using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladrillo : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BolaPrincipal"))
        {
            GameManager gameManager = GameObject.FindAnyObjectByType<GameManager>();
            gameManager.puntos += 100;
            Destroy(this.gameObject);
        }
    }

}
