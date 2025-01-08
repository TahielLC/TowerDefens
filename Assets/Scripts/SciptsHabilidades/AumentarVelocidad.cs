using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuffDeVelocidad", menuName = "Habilidad/BuffDeVelocidad")]
public class AumentarVelocidad : Habilidad
{
    public override void AplicarHabilidad(Einteligente enemyInt)
    {
        throw new System.NotImplementedException();
    }

    public float amentarVelocidad = 0f;
    public float tiempoDelBuff = 1.5f;
    public override void AplicarHabilidadFuerte(Efuerte enemyFuerte)
    {
        if (enemyFuerte.nivelMutacion == NivelMutacionFuerte.Nivel2)
        {
            Debug.Log("Habilidad de velocidad aplicada");
            enemyFuerte.StartCoroutine(ActivarDurante(enemyFuerte));

        }
    }

    private IEnumerator ActivarDurante(Efuerte efuerte)
    {

        foreach (var aliado in efuerte.aliados)
        {
            aliado.cooldownAtaque -= amentarVelocidad;
        }
        yield return new WaitForSeconds(tiempoDelBuff);
        foreach (var aliado in efuerte.aliados)
        {
            aliado.cooldownAtaque += amentarVelocidad;
        }
    }
    private void VelocidadAliadosAtk()
    {
        // que active un aura de velocidad de ataque por un momento
    }

}
