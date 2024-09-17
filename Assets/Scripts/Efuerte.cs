using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Efuerte : Enemy
{

    [Header("Atacar De Efuerte")]
    public float fuerza = 10f;
    private float acumularFuerza;
    public float fuerzaGanadaAtq;
    public float velocidadAtaque;
    public bool atacando = false; // hay que dejar de atacar cuando me quede sin torres 

    [Header("Mis alidos")]
    public List<Enemy> aliados = new List<Enemy>();
    private Enemy aliadoActual;
    public float rangoAliados;

    [Header("Habilidades")]
    public List<Habilidad> habilidades;
    public float dureza;

    [Header("Nivel de Mutacion")]
    public NivelMutacion nivelMutacion = NivelMutacion.Nivel0;
    private NivelMutacion nivelMutacionAnterior;

    void Start()
    {
        fuerzaBase = fuerza;
        durezaSimple = dureza;
        currentLife = maxlife;
        StartCoroutine(CooldownAtacar());
    }

    // Update is called once per frame
    void Update()
    {

        ReunirAliados();
        TorreDetection();
        LookAtRotation();
    }
    //Refactorizar de la clase padre hacer que resiva un lista y trabaje con ella
    public void ReunirAliados()
    {

        aliados = Physics.OverlapSphere(transform.position, rangoAliados).Where(currentAliado => currentAliado.GetComponent<Enemy>()).Select(currentAliado => currentAliado.GetComponent<Enemy>()).ToList();
        if (aliados.Count > 0)
        {
            aliadoActual = aliados[0];
        }
        else if (aliados.Count == 0)
        {
            aliadoActual = null;
        }
    }
    private void OnDrawGizmos()
    {
        RangoDeTorres();
        RangoDeAlidados();
    }
    private void RangoDeTorres()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    private void RangoDeAlidados()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoAliados);
    }

    public IEnumerator CooldownAtacar()
    {
        while (true)
        {
            if (torreActual)
            {

                if (atacando && !torreActual.torreInactiva)
                {
                    Debug.Log("Entro a la fuerza ganada: " + fuerzaGanadaAtq);
                    fuerzaGanadaAtq++;
                }
                acumularFuerza += fuerzaBase + fuerzaGanadaAtq;
                if (torres != null)
                {
                    Atacar();
                }
                fuerza = acumularFuerza; // fuerza acumulada
                yield return new WaitForSeconds(velocidadAtaque);

            }
            yield return null;
        }

    }

    private void Atacar()
    {
        atacando = true;
        torreActual.RecibirDanno(acumularFuerza);
    }







    private void VelocidadAliadosAtk()
    {
        // que active un aura de velocidad de ataque por un momento
    }

    private void AutoRegeneracion()
    {
        // activa durante el ataque una regeneracion de vida 
    }

    private void AumentoDeFuerza()
    {
        //Durante el ataque de este sobre las torres ganara mas fuerza , PASIVA
    }
    private void Irse()
    {
        // se existe una posibilidad de que auto backee solo,
    }
    private void GolpeMortal()
    {
        // va a agarrar un aliado a su distancia disponible , y lo va a azotar contra la torre 
        // haciendo una cantidad de danno considerable
    }
    // Start is called before the first frame update
}
