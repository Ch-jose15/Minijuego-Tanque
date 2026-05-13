using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputProvider
{
    //Movimiento
    float GetMoveInput();
    float GetRotationInput();

    //Disparo
    bool GetFireInput();

    //Torreta
    float GetTurretInput();
}
