using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AumentarIngeligenciPasiva", menuName = "Habilidad/AumentarIngeligenciPasiva")]
public class AumentarInteligencia : Habilidad
{

    public override void AplicarHabilidad(Einteligente enemyInt)
    {

        if (enemyInt.tiempoTranscurrido >= enemyInt.momentoDeMutar)
        {
            float incrementarInteligencia = 10f;
            enemyInt.inteligenciaBase += incrementarInteligencia;

            enemyInt.tiempoTranscurrido = 0;
        }

    }

    public override void AplicarHabilidadFuerte(Efuerte enemyInt)
    {

    }



}
