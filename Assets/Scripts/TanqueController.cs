using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class TanqueController : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private IInputProvider inputProvider;

    [Header("Referencias de Tanque")]
    [SerializeField] private Pista pistaLeft;
    [SerializeField] private Pista pistaRight;
    [SerializeField] private Transform turretTransform;

    [Header("Movimiento")]
    [SerializeField] private float moveAceleration = 0.1f;
    [SerializeField] private float moveDeceleration = 0.2f;
    [SerializeField] private float moveSpeedMax = 2.5f;

    [Header("Rotacion del Cuerpo")]
    [SerializeField] private float rotateAceleration = 4f;
    [SerializeField] private float rotateDeceleration = 10f;
    [SerializeField] private float rotateSpeedMax = 130f; 

    [Header("Rotación de Torreta")]
    [SerializeField] private float turretRotateSpeed = 180f;

    private float moveSpeed = 0f;
    private float moveSpeedReverse = 0f;
    private float rotateSpeedRight = 0f;
    private float rotateSpeedLeft = 0f;

    /*-----------------------------------------------------------------------------------------*/

    private void Start()
    {
        if (inputProvider == null) inputProvider = GetComponent<IInputProvider>();
        if (inputProvider == null) Debug.LogError($"[{gameObject.name})] No se encontró IInputProvider. Asigna PlayerInputProvider en el Inspector.", gameObject);
    }

    /*-----------------------------------------------------------------------------------------*/

    private void Update()
    {
        if (inputProvider == null) return;
        HandleMovement();
        HandleRotation();
        HandleTurretRotation();
        UpdateAnimations();
    }

    /*-----------------------------------------------------------------------------------------*/

    private void HandleMovement()
    {
        float moveInput = inputProvider.GetMoveInput();

        if (moveInput > 0)
        {
            moveSpeed = Mathf.Min(moveSpeed + moveAceleration, moveSpeedMax);
            moveSpeedReverse = Mathf.Max(moveSpeedReverse - moveDeceleration, 0);
        }
        else if (moveInput < 0)
        {
            moveSpeedReverse = Mathf.Min(moveSpeedReverse + moveAceleration, moveSpeedMax);
            moveSpeed = Mathf.Max(moveSpeed - moveDeceleration, 0);
        }
        else
        {
            moveSpeed = Mathf.Max(moveSpeed - moveDeceleration, 0);
            moveSpeedReverse = Mathf.Max(moveSpeedReverse - moveDeceleration, 0);
        }

        float finalSpeed = moveSpeed - moveSpeedReverse;
        transform.Translate(0f, finalSpeed * Time.deltaTime, 0f);
    }

    /*-----------------------------------------------------------------------------------------*/

    private void HandleRotation()
    {
        float rotationInput = inputProvider.GetRotationInput();
    }

    /*-----------------------------------------------------------------------------------------*/

    private void HandleTurretRotation()
    {
        
    }

    /*-----------------------------------------------------------------------------------------*/

    private void UpdateAnimations()
    {
        
    }
}
