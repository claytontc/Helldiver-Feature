using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public float moveforce = 5f;
    private PlayerControls playerControl;

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
    }
}
