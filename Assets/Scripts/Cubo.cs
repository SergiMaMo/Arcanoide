using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubo : MonoBehaviour
{
    private BoxCollider2D _collider2D;
    private void Start()
    {
        CambiarColorComponent cambiarColor = this.GetComponent<CambiarColorComponent>();
        cambiarColor.CambiarColor(Color.red);
        _collider2D = this.GetComponent<BoxCollider2D>();
    }
    private void OnCollisionExit2D(Collision2D collision)
    { 
    }
}
