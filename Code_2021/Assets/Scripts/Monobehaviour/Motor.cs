using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent (typeof (Player))]
public class Motor : MonoBehaviour {
    Player player;
    float ySpeed;

    private void Awake () {
        player = GetComponent<Player> ();
    }

    private float GetGravity () {
        if (player.CharacterController.isGrounded && player.CharacterController.SlopeAngle () != float.MaxValue) {
            ySpeed = 0f;
            return -50f;
        }

        ySpeed += -9.8f * Time.deltaTime;
        return ySpeed;
    }

    public void HandleRotation (Quaternion targetRotation) {
        transform.rotation = Quaternion.Slerp (transform.rotation , targetRotation , player.Attributes.RotationSpeed.Value * Time.deltaTime);
    }

    public void HandleLocomotion (Vector2 movementInput, float speed) {
        Vector3 movementDirection = new Vector3 (movementInput.x * speed , GetGravity () , movementInput.y * speed);
        player.CharacterController.Move (transform.TransformDirection (movementDirection) * Time.deltaTime);
    }

    public void HandleSlippingInput (Vector2 movementInput, float movementSpeed, Vector3 slidingDirection, float slidingSpeed) {
        Vector3 movementVelocity = new Vector3 (movementInput.x * movementSpeed , GetGravity () , movementInput.y * movementSpeed);
        movementVelocity = transform.TransformDirection (movementVelocity);
        movementVelocity += (slidingDirection * slidingSpeed);
        player.CharacterController.Move (movementVelocity * Time.deltaTime);
    }
}
