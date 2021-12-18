using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snippets : MonoBehaviour
{
    /*

    FROM PCAnyState.cs

    protected virtual void InitializeCallbacks () {
        player.PlayerInput.CharacterInput.Walk.started += OnWalkPressed;
        player.PlayerInput.CharacterInput.Jump.started += OnJumpPressed;
    }

    protected virtual void DeregisterCallbacks () {
        player.PlayerInput.CharacterInput.Walk.started -= OnWalkPressed;
        player.PlayerInput.CharacterInput.Jump.started -= OnJumpPressed;
    }

    protected virtual void OnWalkPressed (InputAction.CallbackContext context) {
        player.ToggleWalking ();
    }

    protected virtual void OnJumpPressed (InputAction.CallbackContext context) {
        stateMachine.ChangeState (player.StateJumping);
    }

    protected virtual void PollSprinting () {
        if (player.PlayerInput.CharacterInput.Sprint.ReadValue<float> () == 1) stateMachine.ChangeState (player.StateSprinting);
    }

    protected virtual void PollSlipping () {
        if (player.CharacterController.isGrounded && !player.CharacterController.SureFooted ()) {
            if (slipTime >= hangTime) stateMachine.ChangeState (player.StateSlipping);
            else slipTime += Time.deltaTime;
        } else slipTime = 0f;
    }

    protected virtual void PollGrounded () {
        if (!player.CharacterController.isGrounded) {
            if (fallTime >= hangTime) stateMachine.ChangeState (player.StateFalling);
            else fallTime += Time.deltaTime;
        } else fallTime = 0f;
    }

    protected virtual void FaceMouseInput () {
        Plane normalPlane = new Plane (Vector3.up , player.transform.position);
        Ray ray = player.Cam.ScreenPointToRay (player.PlayerInput.CharacterInput.Cursor.ReadValue<Vector2> ());
        if (normalPlane.Raycast (ray , out float hitDistance)) {
            Vector3 hitPoint = ray.GetPoint (hitDistance);
            targetRotation = Quaternion.LookRotation (hitPoint - player.transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
        }
        player.Motor.HandleRotation (targetRotation);
    }

    protected virtual void Locomotion () {
        Vector2 movementInput = player.PlayerInput.CharacterInput.Locomotion.ReadValue<Vector2> ();
        Vector3 movementVelocity = new Vector3 (movementInput.x , 0f , movementInput.y) * speed;
        player.Motor.AddVelocity (movementVelocity , MoveType.Internal);
    }

    FROM PCSlipping.cs

    protected override void Locomotion () {
        speed = player.Attributes.Speed.Value;
        if (player.CharacterController.SlopeAngle () != float.MaxValue) {
            Vector3 slipVelocity = player.CharacterController.SlopeDirection () * (-3f - Time.deltaTime);
            player.Motor.AddVelocity (slipVelocity , MoveType.External);
        }
        base.Locomotion ();
    }

    */
}
