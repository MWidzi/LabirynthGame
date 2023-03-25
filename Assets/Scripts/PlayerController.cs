using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float playerSpeed = 12f;
    CharacterController characterController;

    public Transform groundCheck;
    public LayerMask groundMask;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();

    }

    private void Update()
    {
        RaycastHit hit;
        bool isGrounded = Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down), out hit, 0.4f, groundMask);

        if (isGrounded)
        {
            string terrainType = hit.collider.gameObject.tag;

            switch (terrainType)
            {
                default:
                    playerSpeed = 12f;
                    break;
                case "SlowSpeed":
                    playerSpeed = 3f;
                    break;
                case "HighSpeed":
                    playerSpeed = 20f;
                    break;
            }
        }

        PlayerMove();
    }

    private void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * playerSpeed * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "Pickup")
        {
            hit.gameObject.GetComponent<PickUp>().Picked();
        }
    }
}
