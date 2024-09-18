using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using System.Linq;
using UnityEngine.UI;
using System.Dynamic;
public class Tower : MonoBehaviour
{
    public string towerName;
    public string towerDescrip;

    public float buyPrice;
    public float sellPrice;

    //public LayerMask layerDetection; // esto es para detectar la entrada del enemigo
    public float range;
    public float dmg = 0;
    public float timetoShot;
    public Enemy currenTarget;
    public List<Enemy> listCurrenTargets = new List<Enemy>();

    [Header("Life")]
    public float life = 100;
    public float currentLife = 0;
    public Image fillLifeImage;
    public bool torreInactiva;

    public Transform rotationPart;
    private void Update()
    {
        EnemyDetection();
        LookRotation();
    }
    public void RecibirDanno(float danno)
    {
        var nwLife = currentLife - danno;
        if (torreInactiva)
        {
            return;
        }
        if (nwLife <= 0)
        {
            TorreInactiva();
        }
        currentLife = nwLife;
        var fillValue = currentLife * 1 / 100;

        fillLifeImage.fillAmount = fillValue;
        currentLife = nwLife;
    }
    public void TorreInactiva()
    {
        torreInactiva = true;
        Debug.Log("torre inactiva");
        currentLife = 0;
        fillLifeImage.fillAmount = 0;
        gameObject.SetActive(false);
    }
    private void Start()
    {
        currentLife = life;
        StartCoroutine(ShootTimer());
    }
    private void EnemyDetection()
    {
        listCurrenTargets = Physics.OverlapSphere(transform.position, range).Where(currentEnemy => currentEnemy.GetComponent<Enemy>()).Select(currentEnemy => currentEnemy.GetComponent<Enemy>()).Where(currentEnemy => !currentEnemy.isDead).ToList();
        if (listCurrenTargets.Count > 0)
        {
            currenTarget = listCurrenTargets[0];
        }
        else if (listCurrenTargets.Count == 0)
        {
            currenTarget = null;
        }

    }
    private void LookRotation()
    {
        if (currenTarget)
        {
            rotationPart.LookAt(currenTarget.transform);
        }
    }

    private IEnumerator ShootTimer()
    {
        while (true)
        {
            if (currenTarget)
            {
                Shoot();
                yield return new WaitForSeconds(timetoShot);
            }
            yield return null;
        }

    }
    private void Shoot()
    {
//        Debug.Log(currenTarget.currentLife + " vida del zonbi");
        currenTarget.TakeDamage(dmg);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);

    }
}
