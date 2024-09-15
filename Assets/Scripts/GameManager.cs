using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform puntoSpawn;
    private Transform torreTarget;
    public Transform puntoRetorno;

    GameObject enemyInstancia;
    // Start is called before the first frame update

    private void Spawn()
    {

        enemyInstancia = Instantiate(enemyPrefab, puntoSpawn.position, puntoSpawn.rotation);

        torreTarget = enemyInstancia.GetComponent<Enemy>().torreActual.transform;

        enemyInstancia.GetComponent<Steering3d>().target = torreTarget.Find("Origen");
        enemyInstancia.GetComponent<Flee>().target = torreTarget.Find("Origen");
    }
    private void Awake()
    {

        Spawn();
    }
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {


    }
}
