using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Transform target;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
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
            Recycle();
        }
    }

    private void Recycle()
    {
        GetComponentInParent<ObjectPool>().AddToQueue(gameObject);
        gameObject.SetActive(false);
    }

    public static float DirToAngle(Vector2 dir) => Mathf.Atan2(dir.y, dir.x);
}
