using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiinputprovider : MonoBehaviour, IInputProvider
{
    [SerializeField] private Transform targetTank;

    [Header("Comportamiento IA")]
    [SerializeField] private float stoppingDistance = 3f;
    [SerializeField] private float fireRange = 10f;

    private float fireCooldown = 0f;

    /*-----------------------------------------------------------------------------------------*/

    private void Update()
    {
        if (fireCooldown > 0) fireCooldown -= Time.deltaTime;
    }

    /*-----------------------------------------------------------------------------------------*/

    public float GetMoveInput()
    {
        return 0f;
    }

    /*-----------------------------------------------------------------------------------------*/

    public float GetRotationInput()
    {
        return 0f;
    }

    /*-----------------------------------------------------------------------------------------*/

    public float GetTurretInput()
    {
        return 0f;
    }

    /*-----------------------------------------------------------------------------------------*/

    public bool GetFireInput()
    {
        return false;
    }

    /*-----------------------------------------------------------------------------------------*/
    
    public void SetTarget(Transform target)
    {
        targetTank = target;
    }
}
