using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawPoint : MonoBehaviour
{
    public GameObject[] prefab;
    [SerializeField] float radioSpawn = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        Spaw();
    }

    void Spaw()
    {
        for (int i = 0; i < prefab.Length; i++)
        {
            // Calcula el ángulo para cada objeto
            float angle = i * Mathf.PI * 2 / prefab.Length;
            Vector3 newSpawPoins = new Vector3(Mathf.Cos(angle) * radioSpawn, 0, Mathf.Sin(angle) * radioSpawn) + transform.position;
            Instantiate(prefab[i], newSpawPoins, Quaternion.identity);
        }
    }
}
