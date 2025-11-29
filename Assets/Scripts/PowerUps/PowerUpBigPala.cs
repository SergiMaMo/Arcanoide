using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerUpBigPala : PowerUpBase
{
    private int tiempoPowerUp = 0;
    public override void Apply()
    {
        base.Apply();
        tiempoPowerUp = 5;

        GameManager.Instance.StartCoroutine(PalaGrande());

    }

    public IEnumerator PalaGrande()
    {
        GameObject pala = GameObject.FindGameObjectWithTag("Pala");

        float tamanoPala = (float)(pala.transform.localScale.x * 1.33);

        Vector2 vectorfinal = new Vector2();
        vectorfinal.y = pala.transform.localScale.y;
        vectorfinal.x = tamanoPala;

        pala.transform.localScale = vectorfinal;


        while (tiempoPowerUp > 0)
        {
            yield return new WaitForSeconds(1f);

            tiempoPowerUp--;
        }

        vectorfinal = new Vector2();
        vectorfinal.y = pala.transform.localScale.y;
        vectorfinal.x = 2;

        pala.transform.localScale = vectorfinal;

    }
}
