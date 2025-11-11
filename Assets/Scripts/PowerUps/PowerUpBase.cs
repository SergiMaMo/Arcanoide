using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase: MonoBehaviour
{
    public virtual void Apply()
    {
        Debug.Log("PowerUp adquirido");
    }
    public virtual void Destroy()
    {
        Destroy(gameObject);
    }
}
