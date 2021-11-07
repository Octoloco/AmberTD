using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    enum TowerTypeEnum { Normal, Slow, Area }

    [SerializeField]
    private TowerTypeEnum towerType = TowerTypeEnum.Normal;
    [SerializeField]
    private float fireRate;

    private ObjectPool ammoPool;
    private List<Transform> enemiesInRange;
    private float fireTimer;
    private Transform target;


    private void Awake()
    {
        gameObject.SetActive(false);
    }

    void Start()
    {
        enemiesInRange = new List<Transform>();
    }

    void Update()
    {
        LookAtTarget();

        //When ready to fire projectile and there is a target, it will shoot
        if (fireTimer > 0)
        {
            fireTimer -= Time.deltaTime;
        }
        else
        {
            if (target != null)
            {
                fireTimer = fireRate;
                Fire();
            }
        }
    }

    private void ChooseTarget()
    {
        //If there is only one enemy in range, target it. If more than 1, calculate the one that is closest and target that one.
        if (enemiesInRange.Count > 0)
        {
            if (enemiesInRange.Count < 2 || target == null)
            {
                target = enemiesInRange[0];
            }
            else
            {
                foreach (Transform e in enemiesInRange)
                {
                    float distanceToCurrentTarget = (target.position - transform.position).magnitude;
                    float distanceToCurrentEnemy = (e.position - transform.position).magnitude;

                    if (distanceToCurrentEnemy < distanceToCurrentTarget)
                    {
                        target = e;
                    }
                }

            }
        }
    }

    private void LookAtTarget()
    {
        ChooseTarget();

        if (target != null)
        {
            Vector2 direction = (Vector2)target.transform.position - (Vector2)transform.position;
            float newRotation = DirToAngle(direction);
            newRotation = newRotation * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, newRotation);
        }
    }

    private void Fire()
    {
        GameObject newProjectile = ammoPool.GetObjectFromPool();
        newProjectile.GetComponent<ProjectileScript>().SetTarget(target);
        newProjectile.transform.rotation = transform.rotation;
        newProjectile.transform.position = transform.position;
    }

    public void Initialize(Vector3 newPosition, ObjectPool pool)
    {
        //Sets the tower in the correct position
        ammoPool = pool;
        transform.position = newPosition;
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //When enemy enters the range of the tower, add to possible targets list
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Added!");
            enemiesInRange.Add(collision.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Removed!");
        if (collision.gameObject.tag == "Enemy")
        {
            enemiesInRange.Remove(collision.transform);
        }
        target = null;
    }

    public static float DirToAngle(Vector2 dir) => Mathf.Atan2(dir.y, dir.x);
}
