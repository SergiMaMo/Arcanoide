using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorMapas : MonoBehaviour
{
    private int NumeroDeBloques;
    private int[,] matrizDeBloquesFinal;
    private void Start()
    {
        NumeroDeBloques = Constants.BLOQUES_NIVEL;
        matrizDeBloquesFinal = crearMatrizMapa();
        Generar_Bloques(matrizDeBloquesFinal);


    }

    private void Generar_Bloques(int[,] matrizDeBloques)
    {
        GameManager.Instance.EliminarTodosLosLadrillos();
        crearLadrillos(matrizDeBloques);

    }

    private void crearLadrillos(int[,] matrizDeBloques)
    {
        foreach(int ladrillo in matrizDeBloques)
        {

        }
    }

    private int[,] crearMatrizMapa()
    {
        int[,] matrizDeBloques = new int[Constants.MAXIMO_FILAS, Constants.MAXIMO_COLUMNAS];
        while(NumeroDeBloques > 0)
        {
            for (int i = 0; i < Constants.MAXIMO_FILAS - 1; i++)
            {
                for (int j = 0; j < Constants.MAXIMO_COLUMNAS -1 ; j++)
                {
                    if (Mathf.Round(Random.Range(0, 3)) == 2)
                    {
                        if(NumeroDeBloques < 0)
                        {
                            return matrizDeBloques;
                        }
                        NumeroDeBloques--;
                        matrizDeBloques[i, j] = matrizDeBloques[i, j] + 1;
                    }
                }
            }
        }
       

        return matrizDeBloques;
    }
}
