using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpLifeUp : PowerUpBase
{
    public override void Apply()
    {
        base.Apply();
        Debug.Log("Life up");
        GameManager gameManager = GameObject.FindAnyObjectByType<GameManager>();

        if(gameManager.vidas < 3)
        {
            gameManager.GanarVida();
        }
    }
}
