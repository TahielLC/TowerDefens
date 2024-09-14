using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CurarAlidos", menuName = "Habilidad/CurarAliados")]
public class CurarAliados : Habilidad
{
    public override void AplicarHabilidad(Einteligente enemy)
    {

        float darHabilidad = 20f;
        float incrementarInteligencia = 2f;
        enemy.inteligenciaBase += incrementarInteligencia;
        
        if (enemy.inteligenciaBase >= darHabilidad)
        {
            foreach (var aliado in enemy.aliados)
            {
                Debug.Log("Hablidad Curar Aplicada");
                aliado.currentLife += 10;
            }

        }



    }


}
