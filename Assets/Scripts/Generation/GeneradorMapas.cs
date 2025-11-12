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
        //matrizDeBloquesFinal = crearMatrizMapa();
    }

    private int[,] crearMatrizMapa()
    {
        int[,] matrizDeBloques = new int[Constants.MAXIMO_FILAS, Constants.MAXIMO_COLUMNAS];
        while(NumeroDeBloques != 0)
        {
            for (int i = 0; i <= Constants.MAXIMO_FILAS; i++)
            {
                for (int j = 0; j <= Constants.MAXIMO_COLUMNAS; j++)
                {
                    if (Random.Range(0, 5) == 5)
                    {
                        NumeroDeBloques--;
                        matrizDeBloques[i, j] = matrizDeBloques[i, j] + 1;
                    }
                }
            }
        }
       

        return matrizDeBloques;
    }
}
