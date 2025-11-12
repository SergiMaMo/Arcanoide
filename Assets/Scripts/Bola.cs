using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    public float velocidadBola;
    public float AnguloDeLanzamientoInicial;
    private Vector2 posicionInicial;
    private bool _isMoving = false;
    // Start is called before the first frame update
    private void Start()
    {
        posicionInicial = this.transform.position;
        
    }

    public void ResetearAPosicionInicial()
    {
        _isMoving = false;
        _rigidBody.velocity = Vector2.zero;
        this.transform.position = posicionInicial;
        GameObject pala = GameObject.FindGameObjectWithTag("Pala");
        this.transform.parent = pala.transform;
        

    }
    public void LanzarBola()
    {
        _rigidBody  = gameObject.GetComponent<Rigidbody2D>();
        
        _rigidBody.velocity = Vector2.zero;
        Vector2 DireccionInicial = new Vector2(0 ,  1);
        _rigidBody.AddForce(DireccionInicial * velocidadBola, ForceMode2D.Impulse);

        _isMoving = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pala"))
        {
            if (_isMoving){
                GameObject pala = GameObject.FindGameObjectWithTag("Pala");
                ContactPoint2D puntoDeContacto;
                puntoDeContacto = collision.GetContact(0);
                Vector3 posicionGlobalDeLaPala = pala.transform.position;
                float IndiceDeRebote = puntoDeContacto.point.x - posicionGlobalDeLaPala.x;
                Vector2 ReboteSegunImpacto = new Vector2(IndiceDeRebote , 1);
                _rigidBody.velocity = Vector2.zero;
                _rigidBody.AddForce(ReboteSegunImpacto.normalized * velocidadBola, ForceMode2D.Impulse);
            }
            
              
        }
    }
}
