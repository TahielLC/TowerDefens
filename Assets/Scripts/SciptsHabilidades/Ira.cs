using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ira", menuName = "Habilidad/Ira")]
public class Ira : Habilidad
{
    public float tiempoDelBuff = 1.5f;
    public float aumentarVelocidad;
    public override void AplicarHabilidad(Einteligente enemyInt)
    {
        throw new System.NotImplementedException();
    }

    public override void AplicarHabilidadFuerte(Efuerte enemyFuerte)
    {
        // se bufea durante 1.5 de velocidad de ataque y danio
        if (enemyFuerte.nivelMutacion == NivelMutacionFuerte.Nivel3)
        {
            Debug.Log("estoy en ira");
            enemyFuerte.StartCoroutine(Ira1(enemyFuerte));
        }


    }
    private IEnumerator Ira1(Efuerte efuerte)
    {
        efuerte.velocidadAtaque -= aumentarVelocidad;
        yield return new WaitForSeconds(tiempoDelBuff);
        efuerte.velocidadAtaque += aumentarVelocidad;
    }
}
