using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    public float velocidadBola;
    public float AnguloDeLanzamientoInicial;
    private bool _isMoving = false;
    private Vector2 posicionInicial;

    // Start is called before the first frame update
    private void Start()
    {
        posicionInicial = this.transform.position;
        
    }

    public void ResetearAPosicionInicial()
    {
        this.transform.position = posicionInicial;
        GameObject pala = GameObject.FindGameObjectWithTag("Pala");
        this.transform.parent = pala.transform;
        _rigidBody.velocity = Vector2.zero;

    }
    public void LanzarBola()
    {
        _isMoving = true;

        _rigidBody = gameObject.GetComponent<Rigidbody2D>();

        _rigidBody.velocity = Vector2.zero;
        Vector2 DireccionInicial = new Vector2(Random.Range(-AnguloDeLanzamientoInicial, AnguloDeLanzamientoInicial) ,  1);
        _rigidBody.AddForce(DireccionInicial * velocidadBola, ForceMode2D.Impulse);
    }
    private void Awake()
    {  
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Pala"))
        {

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
