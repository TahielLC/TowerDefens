using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GritoDeFuerza", menuName = "Habilidad/GritoDeFuerza")]
public class GritoDeFuerza : Habilidad
{
    public override void AplicarHabilidad(Einteligente enemyInt)
    {
        throw new System.NotImplementedException();
    }
    public float aumentoDeDureza = 3f;
    public override void AplicarHabilidadFuerte(Efuerte enemyFuerte)
    {
        if (enemyFuerte.nivelMutacion == NivelMutacionFuerte.Nivel1)
        {
            Debug.Log("Estoy en Grito de fuerza");
            foreach (var aliado in enemyFuerte.aliados)
            {
                aliado.durezaSimple += aumentoDeDureza;
            }

        }
    }

}
