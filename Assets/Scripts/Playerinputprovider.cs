
using UnityEngine;

public class Playerinputprovider : MonoBehaviour, IInputProvider
{
    [Header("Movimiento")]
    [SerializeField] private KeyCode keyMoveForward = KeyCode.W;
    [SerializeField] private KeyCode keyMoveReverse = KeyCode.S;

    [Header("Rotacion del Cuerpo")]
    [SerializeField] private KeyCode keyRotateLeft = KeyCode.A;
    [SerializeField] private KeyCode keyRotateRight = KeyCode.D;

    [Header("Rotacion de la Torreta")]
    [SerializeField] private KeyCode keyTurretLeft = KeyCode.Q;
    [SerializeField] private KeyCode keyTurretRight = KeyCode.E;

    [Header("Disparo")]
    [SerializeField] private KeyCode keyFire = KeyCode.Space;

    /*-----------------------------------------------------------------------------------------*/

    public float GetMoveInput()
    {
        float moveInput = 0f;
        if (Input.GetKey(keyMoveForward)) moveInput = 1f;
        else if (Input.GetKey(keyMoveReverse)) moveInput = -1f;
        return moveInput;
    }

    /*-----------------------------------------------------------------------------------------*/

    public float GetRotationInput()
    {
        float rotationInput = 0f;
        if (Input.GetKey(keyRotateLeft)) rotationInput = -1f;
        else if (Input.GetKey(keyRotateRight)) rotationInput = 1f; 
        return rotationInput;
    }

    /*-----------------------------------------------------------------------------------------*/

    public float GetTurretInput()
    {
        float turretInput = 0f;
        if (Input.GetKey(keyTurretLeft)) turretInput = -1f;
        else if (Input.GetKey(keyTurretRight)) turretInput = 1f;
        return turretInput;
    }

    /*-----------------------------------------------------------------------------------------*/

    public bool GetFireInput()
    {
        return Input.GetKeyDown(keyFire);
    }
}
