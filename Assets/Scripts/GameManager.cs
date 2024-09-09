using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform puntoSpawn;
    public Transform torreTarget;
    // Start is called before the first frame update
    void Start()
    {
        GameObject enemyInstancia = Instantiate(enemyPrefab, puntoSpawn.position, puntoSpawn.rotation);
        enemyInstancia.GetComponent<Steering3d>().target = torreTarget.Find("Origen");

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
