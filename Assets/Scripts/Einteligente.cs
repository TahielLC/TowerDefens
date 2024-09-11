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
    public List<Enemy> aliados = new List<Enemy>();
    public float rangoAliados = 0;

    public float aMutar = 10f;
    public float tiempoABackear = 25f;
    private float tiempoTranscurrido = 0;
    private Enemy aliadoActual;
    private void LlamadaDBack()
    {
        // aca poder especial de este zoombi el cual hace retornar al resto de zombis       
        ReunirAliados();
        float horaDeBackear = 5f;
        if (horaDeBackear > tiempoABackear)
        {
            foreach (var aliado in aliados)
            {
                aliado.GetComponent<Steering3d>().enabled = false;
                aliado.GetComponent<Flee>().enabled = true;
            }

            // aliados[1].GetComponent<Steering3d>().enabled = false;
            // aliados[1].GetComponent<Flee>().enabled = true;
            // aliados[1] = null;

            Debug.Log("BACK");
        }



    }
    private void ReunirAliados()
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

    private void Mutar(float tiempo)
    {
        // el zoombi muta y se vuelve mas inteligente, podiendo hasta curar enemigos ,al atender a backear
        float darHabilidad = 20f;
        float incrementarInteligencia = 2f;
        inteligenicia += incrementarInteligencia;

        if (inteligenicia >= darHabilidad)
        {

        }


    }

    private void Sacrificar()
    {
        // Sacrifica el zombi mas cercano a el para salvar su vida, sera hasta 2 y entre mas mutado mas zombiz es capaz de sacrificar
    }

    // Start is called before the first frame update
    void Start()
    {
        currentLife = maxlife;
        StartCoroutine(CooldownAtacar());

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
        Debug.Log(ataqueInteligente);
        torreActual.RecibirDanno(ataqueInteligente);

    }

    // Update is called once per frame
    void Update()
    {
        tiempoABackear -= Time.deltaTime;
        tiempoTranscurrido += Time.deltaTime;
        if (tiempoTranscurrido >= aMutar)
        {
            Mutar(tiempoTranscurrido);
            tiempoTranscurrido = 0;
        }
        //Debug.Log(tiempoABackear);
        LlamadaDBack();
        TorreDetection();
        LookAtRotation();
    }
}
