using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    private void Start()
    {
        currentLife = maxlife;
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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(dañoAUnidad);
        }
    }
}
