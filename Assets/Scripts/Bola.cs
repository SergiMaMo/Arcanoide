using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    public float velocidadBola;
    private bool _isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void LanzarBola()
    {
        _isMoving = true;
        _rigidBody = gameObject.GetComponent<Rigidbody2D>();
        _rigidBody.AddForce(new Vector2(1 * Time.deltaTime, velocidadBola * Time.deltaTime ), ForceMode2D.Impulse);
    }
    private void Awake()
    {



        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
