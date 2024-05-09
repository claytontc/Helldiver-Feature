using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public float moveforce = 5f;
    private PlayerControls playerControl;
    private List<int> inputSequence = new List<int>();
    private int index = 0;
    public bool bomb = false;
    public bool gas = false;
    public bool laser = false;
    public bool turret = false;
    public GameObject ball;
    public float ballSpeed = 15f;

    // Start is called before the first frame update
    private void Awake()
    {
        playerControl = new PlayerControls();
        playerControl.Enable();
    }

    public void FixedUpdate()
    {
        Vector2 moveVector = playerControl.PlayerInputs.Movement.ReadValue<Vector2>();
        GetComponent<Rigidbody>().AddForce(new Vector3(moveVector.x, 0, moveVector.y) * moveforce, ForceMode.Force);

        if(inputSequence.Count == 4)
        {
            CheckGasAndTurret();
        }
        else if(inputSequence.Count == 5)
        {
            CheckBombandLaser();
        }
    }

    public void InputUp(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            inputSequence[index] = 1;
            index++;
        }
    }

    public void InputDown(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            inputSequence[index] = 2;
            index++;
        }
    }

    public void InputRight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            inputSequence[index] = 3;
            index++;
        }
    }

    public void InputLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            inputSequence[index] = 4;
            index++;
        }
    }

    public void CheckGasAndTurret()
    {
        if (inputSequence[0] == 2 && inputSequence[1] == 1 && inputSequence[2] == 3 && inputSequence[3] == 4)
        {
            turret = true;
        }
        else if (inputSequence[0] == 3 && inputSequence[1] == 3 && inputSequence[2] == 2 && inputSequence[3] == 3)
        {
            gas = true;
        }
    }

    public void CheckBombandLaser()
    {
        if (inputSequence[0] == 1 && inputSequence[1] == 3 && inputSequence[2] == 2 && inputSequence[3] == 2 && inputSequence[4] == 2)
        {
            bomb = true;
        }
        else if (inputSequence[0] == 3 && inputSequence[1] == 2 && inputSequence[2] == 1 && inputSequence[3] == 3 && inputSequence[4] == 2)
        {
            laser = true;
        }
        else
        {
            inputSequence.Clear();
            index = 0;
        }
    }

    private void OnMouseDown()
    {
        if(bomb || laser || gas || turret)
        {
            ball.GetComponent<Rigidbody>().useGravity = true;
            ball.transform.Translate(Vector3.forward * Time.deltaTime * ballSpeed);
        }
    }
}
