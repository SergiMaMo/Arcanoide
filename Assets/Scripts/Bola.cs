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
                Vector3 posicionLocalDeLaPala = pala.transform.localPosition;

                float IndiceDeRebote = Mathf.Clamp(Mathf.Abs(posicionLocalDeLaPala.x) - Mathf.Abs(puntoDeContacto.point.x), -this.transform.localScale.x / 2, this.transform.localScale.x / 2);
                Vector2 ReboteSegunImpacto = new Vector2(IndiceDeRebote * 20, velocidadBola);
                _rigidBody.velocity = Vector2.zero;
                _rigidBody.AddForce(ReboteSegunImpacto, ForceMode2D.Impulse);
            }
            
              
        }
    }
    private void Awake()
    {  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
