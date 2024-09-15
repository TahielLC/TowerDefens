using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//aplicar patron observer 
[CreateAssetMenu(fileName = "Sacrificar", menuName = "Habilidad/Sacrificar")]
public class Sacrificar : Habilidad
{
    public float porcentajeDeRoboVida = 0.5f;
    public override void AplicarHabilidad(Einteligente enemyInt)
    {
        // Sacrifica el zombi aleatorio a el para salvar su vida, sera hasta 2 y entre mas mutado mas zombiz es capaz de sacrificar
        int cantAliadosAlistados = enemyInt.aliados.Count;
        int indiceAlidaoAleatorio = Random.Range(0, cantAliadosAlistados);
        Enemy aliado = enemyInt.aliados[indiceAlidaoAleatorio];

        switch (enemyInt.nivelMutacion)
        {
            case NivelMutacion.Nivel3:
                // me curo un porcentaje de la vida del enemigo
                if (enemyInt.aliados.Contains(aliado))
                {
                    enemyInt.currentLife += aliado.currentLife * porcentajeDeRoboVida;
                    aliado.currentLife -= aliado.currentLife * porcentajeDeRoboVida;
                    if (aliado.currentLife <= 0)
                    {
                        Debug.Log("Aliado consumido");
                    }
                }
                break;
        }
        // if (enemyInt.nivelMutacion == NivelMutacion.Nivel4)
        // {
        //     // Me curo en con la totalidad de la vida del enemigo
        //     if (enemyInt.aliados.Contains(aliado))
        //     {
        //         enemyInt.currentLife += aliado.currentLife;
        //         aliado.currentLife -= aliado.currentLife;
        //     }
        //     Debug.Log("Aliado consumido");

        // }



    }

}
