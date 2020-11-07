using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float powerJump;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Move(false);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Move(true);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            StopMove();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CheckGround())
            {
                Jump();
            }
        }
    }

    private void StopMove()
    {
        rb.velocity = Vector3.zero;
    }

    private void Move(bool isRight)
    {
        if (isRight)
        {
            //Right
            rb.AddForce(transform.right * speed * Time.deltaTime, ForceMode.VelocityChange);
        }
        else
        {
            //Left
            rb.AddForce(-transform.right * speed * Time.deltaTime, ForceMode.VelocityChange);
        }
    }

    private void Jump()
    {
        rb.AddForce(transform.up * powerJump, ForceMode.Impulse);
    }

    private bool CheckGround()
    {
        Vector3 checkDown = transform.TransformDirection(Vector3.down);

        if (Physics.Raycast(transform.position, checkDown, 1))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
