using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Dynamic;
public class Enemy : MonoBehaviour
{
    [Header("Movement")]
    private int targetIndex = 1;
    public float movementSpeed = 4;
    public float rotationSpeed = 6;

    [Header("Life")]
    public bool isDead;
    public float maxlife = 100;
    public float currentLife = 0;
    public Image fillLifeImage;
    public int dañoAUnidad;
    [Header("Atacar")]
    public float danoEstructuras = 10f;
    public float cooldownAtaque = 2f;
    public List<Tower> torres = new List<Tower>();
    public Tower torreActual;
    public float range = 1f;
    public Transform rotarHacia;


    
    private void Awake()
    {
        TorreDetection();
    }
    private void Start()
    {

        currentLife = maxlife;
        StartCoroutine(CooldownAtacar());
    }
    public void TakeDamage(float dmg)
    {
        var newLife = currentLife - dmg;


        if (isDead)
        {

            return;
        }
        if (newLife <= 0)
        {
            Ondead();
        }
        currentLife = newLife;
        var fillValue = currentLife * 1 / 100;

        fillLifeImage.fillAmount = fillValue;
        currentLife = newLife;
        StartCoroutine(AnimationDamge());
    }
    public IEnumerator CooldownAtacar()
    {
        while (true)
        {
            if (torreActual)
            {
                Atacar();
                yield return new WaitForSeconds(cooldownAtaque);
            }
            yield return null;
        }
    }
    private void Atacar()
    {


        torreActual.RecibirDanno(danoEstructuras);

    }
    public void TorreDetection()
    {
        torres = Physics.OverlapSphere(transform.position, range).Where(currentTorre => currentTorre.GetComponent<Tower>()).Select(currentTorre => currentTorre.GetComponent<Tower>()).ToList();

        if (torres.Count > 0)
        {
            torreActual = torres[0];

        }
        else if (torres.Count == 0)
        {
            torreActual = null;
        }
        
    }
    public void LookAtRotation()
    {
        if (torreActual)
        {
            rotarHacia.LookAt(torreActual.transform);
        }

    }


    private IEnumerator AnimationDamge()
    {
        //activar la ancimacion de que esta tomando daño
        yield return new WaitForSeconds(0.1f);
        //desActivar la ancimacion de que esta tomando daño
    }
    private void Ondead()
    {
        isDead = true;
        Debug.Log("C murio");
        //activar animacion de muerte del enemigo 
        //ver devuelta las animaciones por codigo
        currentLife = 0;
        fillLifeImage.fillAmount = 0;
        //Destroy(this);

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);

    }
    private void Update()
    {
        TorreDetection();
        LookAtRotation();
    }

}
