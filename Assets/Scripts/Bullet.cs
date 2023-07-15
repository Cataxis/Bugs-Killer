using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject newObjectPrefab;
    [SerializeField] private float speed;

    private float destroyDelay = 2f;
    private Rigidbody2D projectileRb;

    private void Awake()
    {
        projectileRb = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction)
    {
        projectileRb.velocity = direction * speed;
        Destroy(gameObject, destroyDelay);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance.Score += 1;
            Destroy(collision.gameObject);
            Instantiate(newObjectPrefab, collision.transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
