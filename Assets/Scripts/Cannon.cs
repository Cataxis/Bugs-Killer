using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] Bullet bulletPrefab;
    [SerializeField, Range(1f, 20f)] private float rotationSpeed;
    [SerializeField, Range(1f, 100f)] private float recoilForce;
    [SerializeField, Range(0f, 1f)] private float recoilDuration;
    private Camera cam;
    [SerializeField] Transform launcher;
    private Vector2 joystickInput;

    private bool isRecoiling = false;
    private Vector2 recoilDirection;
    private float recoilTimer = 0f;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        UpdateInput();

        Vector2 direction = GetAimDirection();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);

        if (isRecoiling)
        {
            Recoil();
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Fire();
            }
        }
    }

    private void UpdateInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        joystickInput = new Vector2(horizontalInput, verticalInput);
    }

    private Vector2 GetAimDirection()
    {
        Vector2 direction = Vector2.zero;

        if (joystickInput.magnitude > 0.1f)
        {
            direction = joystickInput.normalized;
        }
        else if (Input.touchCount > 0)
        {
            Vector2 touchPosition = Input.GetTouch(0).position;
            Vector2 touchWorldPoint = cam.ScreenToWorldPoint(touchPosition);
            direction = (touchWorldPoint - (Vector2)transform.position).normalized;
        }
        else
        {
            Vector2 mouseWorldPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            direction = (mouseWorldPoint - (Vector2)transform.position).normalized;
        }

        return direction;
    }

    private void Fire()
    {
        Bullet bulletObj = Instantiate(bulletPrefab, launcher.position, transform.rotation);
        bulletObj.Launch(transform.up);

        // Apply recoil
        recoilDirection = -transform.up;
        isRecoiling = true;
        recoilTimer = 0f;
    }

    private void Recoil()
    {
        recoilTimer += Time.deltaTime;
        if (recoilTimer <= recoilDuration)
        {
            float recoilProgress = recoilTimer / recoilDuration;
            float currentRecoilForce = recoilForce * (1f - recoilProgress);
            transform.Translate(recoilDirection * currentRecoilForce * Time.deltaTime, Space.World);
        }
        else
        {
            isRecoiling = false;
        }
    }
}
