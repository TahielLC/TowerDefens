using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Efuerte : Enemy
{
    public float fuerza = 10f;



    private void GritoDfuerza()
    {
        // habilidad para aumentar la fuerza a los zombiz
    }

    // Start is called before the first frame update
    void Start()
    {
        fuerzaBase = fuerza;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
