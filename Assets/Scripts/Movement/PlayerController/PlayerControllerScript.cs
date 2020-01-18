using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour {

    float MoveSpeed = 4;
    float gravity = 8;

    Vector3 moveDir = Vector3.zero;

    CharacterController controller;
    Animator anim;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (controller.isGrounded) Move();
    }

    void Move ()
    {
        if (Input.GetKey(KeyCode.W))
        {
            SetMovementSpeed(new Vector3(0, 0, 1));
            SetRotation(0);
            SetAnimation(1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            SetMovementSpeed(new Vector3(0, 0, -1));
            SetRotation(180);
            SetAnimation(1);
        }
        else if (Input.GetKey(KeyCode.A)) {
            SetMovementSpeed(new Vector3(-1, 0, 0));
            SetRotation(-90);
            SetAnimation(1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            SetMovementSpeed(new Vector3(1, 0, 0));
            SetRotation(90);
            SetAnimation(1);
        }
        else
        {
            SetAnimation(0);
        }
    }

    void SetRotation(float degrees)
    {
        Vector3 to = new Vector3(0, degrees, 0);
        transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, 1);
    }

    void SetMovementSpeed(Vector3 directionSpeed)
    {
        moveDir = directionSpeed;
        moveDir *= MoveSpeed;
        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
    }

    void SetAnimation(float currentSpeed)
    {
        anim.SetFloat("MoveSpeed", currentSpeed);
    }
}
