using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanque : MonoBehaviour
{
    public Pista pistaLeft;
    public Pista pistaRight;

    public string keyMoveForward;
    public string keyMoveReverse;
    public string keyRotateLeft;
    public string keyRotateRight;

    bool moveForward;
    bool moveReverse;
    float moveSpeed = 0f;
    float moveSpeedReverse = 0f;
    float moveAceleration = 0.1f;
    float moveDeceleration = 0.2f;
    float moveSpeedMax = 2.5f;

    bool rotateRight = false;
    bool rotateLeft = false;
    float rotateSpeedRight = 0f;
    float rotateSpeedLeft = 0f;
    float rotateAceleration = 4f;
    float rotateDeceleration = 10f;
    float rotateSpeedMax = 130f;

    /*---------------------------------------------------------------------------------*/
      
    void Start()
    {
        
    }

    /*---------------------------------------------------------------------------------*/

    void Update()
    {
        rotateLeft = (Input.GetKeyDown(keyRotateLeft)) ? true : rotateLeft;
        rotateLeft = (Input.GetKeyUp(keyRotateLeft)) ? false : rotateLeft;
        if (rotateLeft) rotateSpeedLeft = (rotateSpeedLeft < rotateSpeedMax) ? rotateSpeedLeft + rotateAceleration : rotateSpeedMax;
        else rotateSpeedLeft = (rotateSpeedLeft > 0) ? rotateSpeedLeft - rotateDeceleration : 0;
        transform.Rotate(0f, 0f, rotateSpeedLeft * Time.deltaTime);

        rotateRight = (Input.GetKeyDown(keyRotateRight)) ? true : rotateRight;
        rotateRight = (Input.GetKeyUp(keyRotateRight)) ? false : rotateRight;
        if (rotateRight) rotateSpeedRight = (rotateSpeedRight < rotateSpeedMax) ? rotateSpeedRight + rotateAceleration : rotateSpeedMax;
        else rotateSpeedRight = (rotateSpeedRight > 0) ? rotateSpeedRight - rotateDeceleration : 0;
        transform.Rotate(0f, 0f, rotateSpeedRight * Time.deltaTime * -1f);

        moveForward = (Input.GetKey(keyMoveForward)) ? true : moveForward;
        moveForward = (Input.GetKeyUp(keyMoveForward)) ? false : moveForward;
        if (moveForward) moveSpeed = (moveSpeed < moveSpeedMax) ? moveSpeed + moveAceleration : moveSpeedMax;
        else moveSpeed = (moveSpeed > 0) ? moveSpeed - moveDeceleration : 0;
        transform.Translate(0f, moveSpeed * Time.deltaTime, 0f);

        moveReverse = (Input.GetKey(keyMoveReverse)) ? true : moveReverse;
        moveReverse = (Input.GetKeyUp(keyMoveReverse)) ? false : moveReverse;
        if (moveReverse) moveSpeedReverse = (moveSpeedReverse < moveSpeedMax) ? moveSpeedReverse + moveAceleration : moveSpeedMax;
        else moveSpeedReverse = (moveSpeedReverse > 0) ? moveSpeedReverse - moveDeceleration : 0;
        transform.Translate(0f, moveSpeedReverse * Time.deltaTime * -1f, 0f);

        if (moveForward | moveReverse | rotateRight | rotateLeft) trackStart();
        else trackStop();
    }

    /*---------------------------------------------------------------------------------*/

    void trackStart()
    {
        pistaLeft.animator.SetBool("isMoving", true);
        pistaRight.animator.SetBool("isMoving", true);
    }

    /*---------------------------------------------------------------------------------*/

    void trackStop()
    {
        pistaLeft.animator.SetBool("isMoving", false);
        pistaRight.animator.SetBool("isMoving", false);
    }
}
