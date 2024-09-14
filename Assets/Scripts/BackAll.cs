using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "BackAll", menuName = "Habilidad/BackAll")]
public class BackAll : Habilidad
{
    public override void AplicarHabilidad(Einteligente enemyInt)
    {

        enemyInt.ReunirAliados();
        float horaDeBackear = 5f;
        if (horaDeBackear > enemyInt.tiempoABackear)
        {
            foreach (var aliado in enemyInt.aliados)
            {
                aliado.GetComponent<Steering3d>().enabled = false;
                aliado.GetComponent<Flee>().enabled = true;
            }

            // aliados[1].GetComponent<Steering3d>().enabled = false;
            // aliados[1].GetComponent<Flee>().enabled = true;
            // aliados[1] = null;

            Debug.Log("Hablidad BACK Aplicada");
        }
    }



}
