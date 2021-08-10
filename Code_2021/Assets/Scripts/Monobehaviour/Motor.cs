using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent (typeof (Player))]
public class Motor : MonoBehaviour {
    Player player;

    private void Awake () {
        player = GetComponent<Player> ();
    }

    private float GetGravity () {
        if (player.CharacterController.isGrounded) return -0.05f;
        else return -9.8f;
    }

    public void HandleRotation (Quaternion targetRotation) {
        transform.rotation = Quaternion.Slerp (transform.rotation , targetRotation , player.Attributes.RotationSpeed.Value * Time.deltaTime);
    }

    public void HandleLocomotion (Vector2 movementInput, float speed) {
        Vector3 movementDirection = new Vector3 (movementInput.x * speed , GetGravity () , movementInput.y * speed);
        player.CharacterController.Move (transform.TransformDirection (movementDirection) * Time.deltaTime);
    }
}
