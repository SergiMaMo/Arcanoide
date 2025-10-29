using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(SpriteRenderer)) ] // hace necesario un gameObject
public class CambiarColorComponent : MonoBehaviour
{
    public Color color;
    private SpriteRenderer spriteRenderer;

    public void CambiarColor(Color color)
    {
        spriteRenderer.color = color;
    }
    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>(); 
    }

    
}
