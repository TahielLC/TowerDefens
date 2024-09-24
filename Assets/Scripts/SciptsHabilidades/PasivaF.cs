using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PasivaF", menuName = "Habildad/Nada")]
public class PasivaF : Habilidad
{
    public override void AplicarHabilidad(Einteligente enemyInt)
    {
        throw new System.NotImplementedException();
    }

    public override void AplicarHabilidadFuerte(Efuerte enemyFuerte)
    {
        if (enemyFuerte.nivelMutacion == NivelMutacionFuerte.Nivel0)
        {
            Debug.Log("Pasiva que no hace nada, activa");
        }
    }


}
