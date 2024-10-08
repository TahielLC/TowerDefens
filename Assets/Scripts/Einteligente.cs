using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;


public class Einteligente : Enemy
{
    [Header("Atacar")]
    public float inteligenicia = 10f;
    public float ataqueInteligente = 4.2f;
    private float sumarAtaque = 0.3f;
    public bool aprendiendo = true;
    [Header("Mis Aliados")]
    public List<Enemy> aliados = new List<Enemy>();
    private Enemy aliadoActual;
    public float rangoAliados = 0;
    [Header("Habilidades")]
    public List<Habilidad> habilidades;
    public float momentoDeMutar = 10f;
    public float tiempoTranscurrido = 0;
    int contador = 0;
    [Header("Nivel Mutacion")]
    public NivelMutacion nivelMutacion = NivelMutacion.Nivel0;
    private NivelMutacion nivelMutacionAnterior;
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
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, rangoAliados);
    }
    public IEnumerator CooldownAtacar()
    {
        float tiempoTranscurrido = 10f;
        float transcurrido = 0;
        while (true)
        {
            if (torreActual)
            {
                Atacar();
                transcurrido += cooldownAtaque;
                if (tiempoTranscurrido == transcurrido)
                {
                    ataqueInteligente += sumarAtaque;
                    transcurrido = 0;
                }
                yield return new WaitForSeconds(cooldownAtaque);
            }
            yield return null;
        }
    }
    private void Atacar()
    {
        //estaAtancando = true;
        Debug.Log(ataqueInteligente);
        torreActual.RecibirDanno(ataqueInteligente);

    }


    // Start is called before the first frame update
    void Start()
    {
        currentLife = maxlife;
        inteligenciaBase = inteligenicia;

        StartCoroutine(CooldownAtacar());

    }

    // Update is called once per frame
    void Update()
    {

        tiempoTranscurrido += Time.deltaTime;
        // mientras tenga torres en su rango seguira aumentando su inteligencia
        if (torres.Count != 0)
        {
            habilidades[0].AplicarHabilidad(this);
        }

        if (nivelMutacion != nivelMutacionAnterior)
        {
            switch (nivelMutacion)
            {

                case NivelMutacion.Nivel1:
                    habilidades[1].AplicarHabilidad(this);
                    break;
                case NivelMutacion.Nivel2:
                    habilidades[2].AplicarHabilidad(this);
                    break;
                case NivelMutacion.Nivel3:
                    habilidades[3].AplicarHabilidad(this);
                    break;

                default:
                    Debug.Log("No tiene nivel asignado");
                    break;
            }

            // Actualizamos el nivel anterior después de aplicar la habilidad
            nivelMutacionAnterior = nivelMutacion;
        }

        ReunirAliados();
        TorreDetection();
        LookAtRotation();
        Debug.Log(nivelMutacion);
    }
}
