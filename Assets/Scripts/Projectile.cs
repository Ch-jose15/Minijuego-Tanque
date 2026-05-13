using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float speed = 20f;
    [SerializeField] private Rigidbody2D rb;

    [Header("Limites")]
    [SerializeField] private float maxDistance = 50f;

    private Vector2 initialPosition;
    private Vector2 direction;
    private float distanceTraveled = 0f;

    /*-----------------------------------------------------------------------------------------*/

    private void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
    }

    /*-----------------------------------------------------------------------------------------*/

    private void FixedUpdate()
    {
        rb.velocity = direction * speed;
        distanceTraveled = Vector2.Distance(initialPosition, (Vector2)transform.position);
        if (distanceTraveled > maxDistance) DestroyProjectile();
        if (IsOutOfBounds()) DestroyProjectile();
    }

    /*-----------------------------------------------------------------------------------------*/

    public void Initialize(Vector2 shootDirection)
    {
        direction = shootDirection.normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        initialPosition = transform.position;
        distanceTraveled = 0f;
    }

    /*-----------------------------------------------------------------------------------------*/

    private bool IsOutOfBounds()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        return screenPoint.x < -0.5f || screenPoint.x > 1.5f || screenPoint.y < -0.5f || screenPoint.y > 1.5f;
    }

    /*-----------------------------------------------------------------------------------------*/

    public void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    /*-----------------------------------------------------------------------------------------*/

    public Vector2 GetDirection()
    {
        return direction;
    }

    /*-----------------------------------------------------------------------------------------*/

    public float GetDistanceTraveled()
    {
        return distanceTraveled;
    }
}
