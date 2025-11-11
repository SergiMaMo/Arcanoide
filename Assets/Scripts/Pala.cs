using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pala : MonoBehaviour
{
    public float Velocity;
    private bool lanzada;
    public GameObject paredDerecha;
    public GameObject paredIzquierda;
    private GameObject bola;
    private float limiteDerecho;
    private float limiteIzquierdo;
    private Vector2 posicionInicial;


    private void Awake()
    {
        Velocity = 5f;
        lanzada = false;
        establecerLimitesDeJuego();
    }

    private void Start()
    {
        posicionInicial = this.transform.position;
        
    }

    public void ResetearAPosicionInicial()
    {
        lanzada = false;
        this.transform.position = posicionInicial;
    }



    private void Update()
    {
        establecerLimitesDeJuego();
        moverPala();
        lanzarBola();
    }
    private void establecerLimitesDeJuego()
    {
        limiteDerecho = (paredDerecha.transform.position.x - paredDerecha.transform.localScale.x / 2) - (this.transform.localScale.x / 2);
        limiteIzquierdo = (paredIzquierda.transform.position.x + paredDerecha.transform.localScale.x / 2) + (this.transform.localScale.x / 2);
    }

    private void lanzarBola()
    {
        
        if (Input.GetKey(KeyCode.Space) && !lanzada)
        {
            lanzada = true;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PowerUpBase powerUp = collision.GetComponent<PowerUpBase>();
       
        if (powerUp != null)
        {
           powerUp.Apply();
           powerUp.Destroy();     
        }
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
