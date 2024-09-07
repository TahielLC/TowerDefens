using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using System.Linq;

public class Tower : MonoBehaviour
{
    public string towerName;
    public string towerDescrip;

    public float buyPrice;
    public float sellPrice;

    //public LayerMask layerDetection; // esto es para detectar la entrada del enemigo
    public float range;
    public float dmg = 0;
    public float timetoShot = 1;

    public Enemy currenTarget;


    public List<Enemy> listCurrenTargets = new List<Enemy>();


    public Transform rotationPart;
    private void Update()
    {
        EnemyDetection();
        LookRotation();
    }
    private void Start()
    {
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
        currenTarget.TakeDamage(dmg);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, range);

    }
}
