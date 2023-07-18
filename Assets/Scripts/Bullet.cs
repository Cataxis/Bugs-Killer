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
            Destroy(collision.gameObject);
            Instantiate(newObjectPrefab, collision.transform.position, Quaternion.identity);
            GameManager.Instance.BugDied();
        }

        if (collision.gameObject.CompareTag("Spikes"))
        {
            Debug.Log("ok");
        }

        Destroy(this.gameObject);
        
    }
}
