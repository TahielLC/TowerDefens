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

    private void Spaw()
    {

        enemyInstancia = Instantiate(enemyPrefab, puntoSpawn.position, puntoSpawn.rotation);

        torreTarget = enemyInstancia.GetComponent<Enemy>().torreActual.transform;

        enemyInstancia.GetComponent<Steering3d>().target = torreTarget.Find("Origen");
        enemyInstancia.GetComponent<Flee>().target = torreTarget.Find("Origen");
    }
    void Start()
    {
        Spaw();
        //Steering3d enemyScript = enemyInstancia.GetComponent<Steering3d>();

        // if (enemyScript != null)
        // {
        //     enemyScript.target = torreTarget;
        // }
    }


    // Update is called once per frame
    void Update()
    {


    }
}
