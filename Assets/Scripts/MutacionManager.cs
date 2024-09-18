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
public enum NivelMutacionFuerte
{
    Nivel0 = 0,
    Nivel1 = 20,
    Nivel2 = 40,
    Nivel3 = 60,
    Nivel4 = 80
}
public class MutacionManager : MonoBehaviour
{
    public Einteligente[] zInteligentes;
    private Einteligente eInteligente;

    public Efuerte[] zFuertes;
    private Efuerte eFuerte;
    //public NivelMutacion nivelMutacion;

    private void ReconocimentoDeZintelig()
    {
        zInteligentes = FindObjectsOfType<Einteligente>();

        if (eInteligente != null)
        {
            eInteligente = zInteligentes[0];

        }
        else
            Debug.Log("No se encontro");
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
    private void ReconocimentoDeZfuete()
    {
        zFuertes = FindObjectsOfType<Efuerte>();

        if (eFuerte != null)
        {
            eFuerte = zFuertes[0];

        }
        else
            Debug.Log("No se encontro");
        if (zFuertes.Length > 0)
        {
            foreach (var obj in zFuertes)
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
    private void AsignarleNivelMutacionFuertes()
    {

        foreach (var zfuerte in zFuertes)
        {
            if (zfuerte.fuerza >= (int)NivelMutacionFuerte.Nivel4)
            {
                zfuerte.nivelMutacion = NivelMutacionFuerte.Nivel4;
            }
            else if (zfuerte.fuerza >= (int)NivelMutacionFuerte.Nivel3)
            {
                zfuerte.nivelMutacion = NivelMutacionFuerte.Nivel3;
            }
            else if (zfuerte.fuerza >= (int)NivelMutacionFuerte.Nivel2)
            {
                zfuerte.nivelMutacion = NivelMutacionFuerte.Nivel2;
            }
            else if (zfuerte.fuerza >= (int)NivelMutacionFuerte.Nivel1)
            {
                zfuerte.nivelMutacion = NivelMutacionFuerte.Nivel1;
            }
            else
            {
                zfuerte.nivelMutacion = NivelMutacionFuerte.Nivel0;
            }
        }
    }

    private void Start()
    {
        ReconocimentoDeZfuete();
        ReconocimentoDeZintelig();

    }
    // Update is called once per frame
    void Update()
    {

        AsignarleNivelMutacion();
        AsignarleNivelMutacionFuertes();

    }
}



