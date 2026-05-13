using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tankshooter : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private TanqueController tanqueController;
    [SerializeField] private Transform turretTransform;
    [SerializeField] private GameObject projectilePrefab;
 
    [Header("Puntos de Disparo")]
    [SerializeField] private Transform[] gunPositions; // Array de cañones
 
    [Header("Configuración de Disparo")]
    [SerializeField] private float shootCooldown = 0.5f;
    [SerializeField] private float projectileSpeed = 20f;
 
    private float lastShotTime = 0f;

    /*-----------------------------------------------------------------------------------------*/
    private void Start()
    {
        if (tanqueController == null) tanqueController = GetComponent<TanqueController>();
        if (projectilePrefab == null) Debug.LogError($"[{gameObject.name}] Projectile Prefab no está asignado en TankShooter", gameObject);
    }

    /*-----------------------------------------------------------------------------------------*/

    private void Update()
    {
        if (lastShotTime > 0) lastShotTime -= Time.deltaTime;
        if (tanqueController.GetFireInput() && CanShoot()) Shoot();
    }

    /*-----------------------------------------------------------------------------------------*/

    private bool CanShoot()
    {
        return lastShotTime <= 0;
    }

    /*-----------------------------------------------------------------------------------------*/

    private void Shoot()
    {
        if (gunPositions == null || gunPositions.Length == 0)
        {
            Debug.LogWarning($"[{gameObject.name}] No hay puntos de disparo asignados", gameObject);
            return;
        }

        Vector2 shootDirection = (Vector2)turretTransform.TransformDirection(Vector3.up);

        foreach (Transform gunPos in gunPositions)
        {
            if (gunPos != null) SpawmProjectile(gunPos.position, shootDirection);
        }

        lastShotTime = shootCooldown;
    }

    /*-----------------------------------------------------------------------------------------*/

    private void SpawmProjectile(Vector3 spawnPosition, Vector2 direction)
    {
        GameObject projectileObj = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
        Projectile projectile = projectileObj.GetComponent<Projectile>();

        if (projectile != null) projectile.Initialize(direction);
        else Debug.LogError($"[{projectileObj.name}] No tiene componente Projectile", projectileObj);

        Rigidbody2D rb = projectileObj.GetComponent<Rigidbody2D>();
        if (rb != null){}
    }

    /*-----------------------------------------------------------------------------------------*/

    public float GetCooldoenRemaining()
    {
        return Mathf.Max(0, lastShotTime);
    }

    /*-----------------------------------------------------------------------------------------*/

    public bool IsReady()
    {
        return CanShoot();
    }

    /*-----------------------------------------------------------------------------------------*/

    public void SetProjectileSpeed(float newSpeed)
    {
        projectileSpeed = newSpeed;
    }

    /*-----------------------------------------------------------------------------------------*/

    public void SetShootCooldown(float newCooldown)
    {
        shootCooldown = newCooldown;
    }
}
