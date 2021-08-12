using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent (typeof (Player))]
public class Motor : MonoBehaviour {
    Player player;
    float ySpeed = -4.5f;

    private void Awake () {
        player = GetComponent<Player> ();
    }

    private float GetGravity () {
        if (player.CharacterController.isGrounded && player.CharacterController.SureFooted ()) {
            ySpeed = 0f;
            return -4.5f;
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

    public void HandleSlidingMovement (Vector3 movementInput, float speed) {
        Vector3 movementDirection = new Vector3 (movementInput.x * speed , GetGravity () , movementInput.z * speed);
        player.CharacterController.Move (movementDirection * Time.deltaTime);
    }
}
