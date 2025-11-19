using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BolaPrincipal"))
        {
            GameManager.Instance.PerderVida();
        }

        PowerUpBase powerUp = collision.GetComponent<PowerUpBase>();

        if (powerUp != null)
        {
            powerUp.Destroy();
        }
    }
}
