using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float damage;
    [SerializeField]
    private float areaRadius;
    [SerializeField]
    private bool appliesSlow;
    [SerializeField]
    private bool areaDamage;
    [SerializeField]
    private float timeToDie = 1.5f;

    private Transform target;

    private float timer;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void Start()
    {
        timer = timeToDie;
    }

    void Update()
    {
        if (timer < 0)
        {
            timer = timeToDie;
        }
        else
        {
            timer -= Time.deltaTime;
        }

        if (target != null)
        {
            Vector2 direction = (Vector2)target.transform.position - (Vector2)transform.position;
            float newRotation = DirToAngle(direction);
            newRotation = newRotation * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, newRotation);
        }
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (areaDamage)
            {
                Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(transform.position, areaRadius);
                foreach(Collider2D e in enemiesHit)
                {
                    if (e.gameObject.tag == "Enemy")
                    {
                        if (appliesSlow)
                        {
                            e.GetComponent<EnemyMovement>().SlowEnemy();
                        }
                        e.GetComponent<HealthScript>().ReduceHealth(damage);
                        Recycle();
                    }
                }
            }
            else
            {
                if (appliesSlow)
                {
                    collision.GetComponent<EnemyMovement>().SlowEnemy();
                }
                collision.GetComponent<HealthScript>().ReduceHealth(damage);
                Recycle();
            }
        }
    }

    private void Recycle()
    {
        GetComponentInParent<ObjectPool>().AddToQueue(gameObject);
        gameObject.SetActive(false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, areaRadius);
    }

    public static float DirToAngle(Vector2 dir) => Mathf.Atan2(dir.y, dir.x);
}
