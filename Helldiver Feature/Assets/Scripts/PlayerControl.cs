using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/*
 * Author: [Cranford, Clayton]
 * Last Updated: [05/09/2024]
 * [File handles the player's movement, strategem inputs, and the throwing of the strategem ball]
 */

public class PlayerControl : MonoBehaviour
{
    public float moveforce = 5f;
    private PlayerControls playerControl;
    private List<int> inputSequence = new List<int>();
    public bool bomb = false;
    public bool gas = false;
    public bool laser = false;
    public bool turret = false;
    public GameObject ball;
    private Vector3 ballStartPos;
    public float ballSpeed = 7.5f;
    private int tempInput;

    // called at the start of the game
    private void Awake()
    {
        playerControl = new PlayerControls();
        playerControl.Enable();
    }

    // called before the first FixedUpdate frame
    private void Start()
    {
        ballStartPos = ball.transform.position;
    }

    //called every frame
    public void FixedUpdate()
    {
        //player movement
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

        //changes the ball's color if a complete strategem input has been entered, indicating the ball is ready to throw
        if(bomb || laser || gas || turret)
        {
            ball.GetComponent<MeshRenderer>().material.color = Color.blue;
        }

        if(inputSequence.Count >= 6 && !bomb && !laser && !gas && !turret)
        {
            resetInputs();
        }
    }

    /// <summary>
    /// Inputs an up to the input sequence
    /// </summary>
    /// <param name="context"></param>
    public void InputUp(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            inputSequence.Add(1);
        }
    }

    /// <summary>
    /// inputs a down to the input sequence
    /// </summary>
    /// <param name="context"></param>
    public void InputDown(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            inputSequence.Add(2);
        }
    }

    /// <summary>
    /// inputs a right to the input sequence
    /// </summary>
    /// <param name="context"></param>
    public void InputRight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            inputSequence.Add(3);
        }
    }

    /// <summary>
    /// inputs a left into the input sequence
    /// </summary>
    /// <param name="context"></param>
    public void InputLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            inputSequence.Add(4);
        }
    }

    /// <summary>
    /// when the input sequence has 4 inputs, checks to see if the sequence matches the code for the gas strike or gatling turret
    /// </summary>
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

    /// <summary>
    /// when the sequence reaches 5 inputs, checks to see if the sequence matches the code for the 500kg bomb or the orbital laser
    /// </summary>
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
    }

    /// <summary>
    /// throws the ball, starts to return the ball, and clears the sequence
    /// </summary>
    /// <param name="context"></param>
    public void Throw(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if (bomb || laser || gas || turret)
            {
                ball.GetComponent<Rigidbody>().useGravity = true;
                ball.GetComponent<Rigidbody>().AddForce(new Vector3(0, 10, 10) * ballSpeed, ForceMode.Impulse);
                StartCoroutine(ReturnBall());
                inputSequence.Clear();
            }
        }
    }

    /// <summary>
    /// returns the ball to the player
    /// </summary>
    /// <returns></returns>
    private IEnumerator ReturnBall()
    {
        yield return new WaitForSeconds(5);
        ball.GetComponent<Rigidbody>().useGravity = false;
        ball.transform.position = ballStartPos;
        ball.GetComponent<MeshRenderer>().material.color = Color.gray;
    }

    /// <summary>
    /// empties the last 5 inputs of the sequence
    /// </summary>
    private void resetInputs()
    {
        tempInput = inputSequence[5];
        inputSequence.Clear();
        inputSequence.Add(tempInput);
    }
}
