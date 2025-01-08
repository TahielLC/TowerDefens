using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawPoint : MonoBehaviour
{
    public GameObject[] prefab;
    [SerializeField] float radioSpawn = 1.5f;

    private List<GameObject> instanciasCreadas = new List<GameObject>();
    private GameObject laInstancia;

    [SerializeField] private Transform irAqui;
    private Tower[] torresTargetEscena;
    private Transform torreTarget;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();

    }
    private void Awake()
    {

    }
    void Spawn()
    {
        torresTargetEscena = FindObjectsOfType<Tower>();
        if (torresTargetEscena.Length > 0)
        {
            foreach (var obj in torresTargetEscena)
            {
                Debug.Log("Objeto encontrado: " + obj.gameObject.name);
            }
        }
        else
        {
            Debug.LogWarning("No se encontraron objetos con MyComponent en la escena.");
        }
        for (int i = 0; i < prefab.Length; i++)
        {
            // Calcula el ángulo para cada objeto
            float angle = i * Mathf.PI * 2 / prefab.Length;
            Vector3 newSpawPoins = new Vector3(Mathf.Cos(angle) * radioSpawn, 0, Mathf.Sin(angle) * radioSpawn) + transform.position;


            GameObject instancia = Instantiate(prefab[i], newSpawPoins, Quaternion.identity);

            // Intentar asignar un objetivo inicial
            Enemy enemyScript = instancia.GetComponent<Enemy>();
            if (torresTargetEscena.Length > 0 && enemyScript.torreActual != null)
            {
                Transform torreTarget = enemyScript.torreActual.transform;
                instancia.GetComponent<Steering3d>().target = torreTarget.Find("Origen");
                instancia.GetComponent<Flee>().target = torreTarget.Find("Origen");
            }
            else
            {
                // Asignar fallback si no hay torres disponibles
                instancia.GetComponent<Steering3d>().target = irAqui;
                instancia.GetComponent<Flee>().target = irAqui;
            }

            instanciasCreadas.Add(instancia);

            ////laInstancia = Instantiate(prefab[i], newSpawPoins, Quaternion.identity);
            //torreTarget = torresTargetEscena[0].transform;
            ///torreTarget = laInstancia.GetComponent<Enemy>().torreActual.transform;

            ///laInstancia.GetComponent<Steering3d>().target = torreTarget.Find("Origen");
            ///laInstancia.GetComponent<Flee>().target = torreTarget.Find("Origen");
            ///instanciasCreadas.Add(laInstancia);
            // Transform torreTarget = prefab[i].GetComponent<Enemy>().torreActual.transform;
            //refactorizar esto
            //prefab[i].GetComponent<Steering3d>().target = torreTarget.Find("Origen");
        }
    }
    private void Update()
    {
        foreach (var instancia in instanciasCreadas)
        {
            Enemy enemyScript = instancia.GetComponent<Enemy>();

            if (enemyScript == null)
                continue;

            // Verificar si el enemigo tiene una torre objetivo
            if (enemyScript.torreActual != null)
            {
                Transform torreTarget = enemyScript.torreActual.transform;
                instancia.GetComponent<Steering3d>().target = torreTarget.Find("Origen");
                instancia.GetComponent<Flee>().target = torreTarget.Find("Origen");
            }
            else
            {
                // Si no hay torres, mover al punto de fallback
                instancia.GetComponent<Steering3d>().target = irAqui;
                instancia.GetComponent<Flee>().target = irAqui;
            }
        }
        
        // foreach (var laInstancia in instanciasCreadas)
        // {
        //     torreTarget = laInstancia.GetComponent<Enemy>().torreActual.transform;

        //     laInstancia.GetComponent<Steering3d>().target = torreTarget.Find("Origen");
        // }


    }
}
