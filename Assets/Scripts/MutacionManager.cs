using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum NivelMutacion
{
    Nivel0 = 0,
    Nivel1 = 30,
    Nivel2 = 60,
    Nivel3 = 90,
    Nivel4 = 120
}
public class MutacionManager : MonoBehaviour
{
    public Einteligente[] zInteligentes;
    private Einteligente eInteligente;
    //public NivelMutacion nivelMutacion;

    private void ReconocimentoDeZintelig()
    {
        zInteligentes = FindObjectsOfType<Einteligente>();
        eInteligente = zInteligentes[0];

        if (zInteligentes.Length > 0)
        {
            foreach (var obj in zInteligentes)
            {
                Debug.Log("Objeto encontrado: " + obj.gameObject.name);
            }
        }
        else
        {
            Debug.LogWarning("No se encontraron objetos con MyComponent en la escena.");
        }

    }
    private void AsignarleNivelMutacion()
    {
        foreach (var zIntel in zInteligentes)
        {

            foreach (NivelMutacion nivel in Enum.GetValues(typeof(NivelMutacion)))
            {
                if (zIntel.inteligenciaBase == (int)nivel)
                {
                    zIntel.nivelMutacion = nivel;
                }
            }
        }


    }

    private void Start()
    {
        ReconocimentoDeZintelig();

    }
    // Update is called once per frame
    void Update()
    {

        AsignarleNivelMutacion();


    }
}



