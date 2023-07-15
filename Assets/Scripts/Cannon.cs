using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] Bullet bulletPrefab;
    [SerializeField, Range(1f, 20f)] private float rotationSpeed;
    private Camera cam;
    [SerializeField] Transform launcher;
    private Vector2 joystickInput;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        joystickInput = new Vector2(horizontalInput, verticalInput);

        Vector2 mouseWorldPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mouseWorldPoint - (Vector2)transform.position).normalized;

        if (joystickInput.magnitude > 0.1f)
        {
            direction = joystickInput.normalized;
        }

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);

        if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Fire1"))
        {
            Bullet bulletObj = Instantiate(bulletPrefab, launcher.position, transform.rotation);
            bulletObj.Launch(transform.up);
        }
    }
}

