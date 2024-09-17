using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CurarAlidos", menuName = "Habilidad/CurarAliados")]
public class CurarAliados : Habilidad
{
    public override void AplicarHabilidad(Einteligente enemy)
    {
        // mover esto en donde pertenezca, no esta bien que una habilidad le sume inteligencia
        // float incrementarInteligencia = 2f;
        // enemy.inteligenciaBase += incrementarInteligencia;

        if (enemy.nivelMutacion == NivelMutacion.Nivel1)
        {
            foreach (var aliado in enemy.aliados)
            {
                Debug.Log("Hablidad Curar Aplicada");
                aliado.currentLife += 10;
            }

        }



    }

    public override void AplicarHabilidadFuerte(Efuerte enemyInt)
    {

    }
}
