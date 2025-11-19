using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpLifeUp : PowerUpBase
{
    public override void Apply()
    {
        base.Apply();
        if(GameManager.Instance.getVidas() < 3)
        {
            GameManager.Instance.GanarVida();
        }
    }
}
