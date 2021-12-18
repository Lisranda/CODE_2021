using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Motor {
    Pawn pawn;
    Transform transform;

    public Motor (Pawn pawn) {
        this.pawn = pawn;
        transform = pawn.transform;
    }

    public void HandleLocomotion (Vector3 movementVelocity) {
        pawn.CharacterController.Move (transform.TransformDirection (movementVelocity) * Time.deltaTime);
    }

    public void HandleRotation (Quaternion targetRotation) {
        transform.rotation = Quaternion.Slerp (transform.rotation , targetRotation , pawn.Attributes.RotationSpeed.Value * Time.deltaTime);
    }
}
