using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Einteligente : Enemy
{
    public float inteligenicia = 10f;

    private void LlamadaDBack()
    {
        // aca poder especial de este zoombi el cual hace retornar al resto de zombis

    }
    private void Mutar()
    {
        // el zoombi muta y se vuelve mas inteligente
    }

    private void Sacrificar()
    {
        // Sacrifica el zombi mas cercano a el para salvar su vida, sera hasta 2 y entre mas mutado mas zombiz es capaz de sacrificar
    }

    // Start is called before the first frame update
    void Start()
    {
        currentLife = maxlife;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
