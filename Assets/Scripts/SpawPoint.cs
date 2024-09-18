using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawPoint : MonoBehaviour
{
    public GameObject[] prefab;
    [SerializeField] float radioSpawn = 1.5f;


    private GameObject laIstancia;

    //refactorizar esto
    //public Transform torreTarget;
    private Tower[] torresTargetEscena;
    private Transform torreTarget;
    // Start is called before the first frame update
    void Start()
    {
        Spaw();

    }
    private void Awake()
    {

    }
    void Spaw()
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


            laIstancia = Instantiate(prefab[i], newSpawPoins, Quaternion.identity);
            torreTarget = torresTargetEscena[0].transform;
            //torreTarget = laIstancia.GetComponent<Enemy>().torreActual.transform;

            laIstancia.GetComponent<Steering3d>().target = torreTarget.Find("Origen");
            laIstancia.GetComponent<Flee>().target = torreTarget.Find("Origen");
            // Transform torreTarget = prefab[i].GetComponent<Enemy>().torreActual.transform;
            //refactorizar esto
            //prefab[i].GetComponent<Steering3d>().target = torreTarget.Find("Origen");
        }
    }
}
