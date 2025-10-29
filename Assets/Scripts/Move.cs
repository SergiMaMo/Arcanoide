using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float Velocity;

    public GameObject paredDerecha;
    public GameObject paredIzquierda;
    private GameObject bola;
    private float limiteDerecho;
    private float limiteIzquierdo;
    private float posicionActual;
    private void Awake()
    {
        Velocity = 5f;
        posicionActual = this.transform.localScale.x;
        establecerLimitesDeJuego();
    }

    private void Update()
    {
        establecerLimitesDeJuego();
        moverPala();
        if (Input.GetKey(KeyCode.Space))
        {
            bola = GameObject.FindGameObjectWithTag("BolaPrincipal");
            if (bola != null)
            {
                bola.transform.parent = null;
                Bola bolaComponent = bola.GetComponent<Bola>();
                bolaComponent.LanzarBola();
            }
            else
            {
                throw new ArgumentNullException(nameof(bola));
            }
        }
    }
    private void establecerLimitesDeJuego()
    {
        limiteDerecho = (paredDerecha.transform.position.x - paredDerecha.transform.localScale.x / 2) - (this.transform.localScale.x / 2);
        limiteIzquierdo = (paredIzquierda.transform.position.x + paredDerecha.transform.localScale.x / 2) + (this.transform.localScale.x / 2);
    }

    private void moverPala()
    {
        if (Input.anyKey)
        {
            float moveHorizontal = Input.GetAxisRaw("Horizontal");
            Vector2 vectorfinal = new Vector2();
            vectorfinal.y = this.transform.position.y;
            vectorfinal.x = this.transform.position.x + (moveHorizontal * Time.deltaTime * this.Velocity);
            vectorfinal.x =  Mathf.Clamp(vectorfinal.x, limiteIzquierdo, limiteDerecho);

            this.transform.position = vectorfinal;

        }
        
    }
}
