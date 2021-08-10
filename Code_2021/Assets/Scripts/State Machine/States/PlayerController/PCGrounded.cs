using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PCGrounded : PCAnyState {
    protected Vector2 movementInput;
    protected Quaternion targetRotation;
    protected float speed;

    public PCGrounded (StateMachine stateMachine , Player player) : base (stateMachine , player) {
    }

    public override void OnEnter () {
        base.OnEnter ();
        InitializeCallbacks ();
    }

    public override void OnExit () {
        base.OnExit ();
        DeregisterCallbacks ();
    }

    public override void Tick () {
        base.Tick ();
        FaceMouseInput ();
        Locomotion (); 
    }

    public override void FixedTick () {
        base.FixedTick ();
    }

    protected virtual void InitializeCallbacks () {
        player.PlayerInput.CharacterInput.Walk.started += OnWalkPressed;
        player.PlayerInput.CharacterInput.Sprint.started += OnSprintPressed;
    }

    protected virtual void DeregisterCallbacks () {
        player.PlayerInput.CharacterInput.Walk.started -= OnWalkPressed;
        player.PlayerInput.CharacterInput.Sprint.started -= OnSprintPressed;
    }

    protected virtual void OnWalkPressed (InputAction.CallbackContext context) {
        player.ToggleWalking ();
    }

    protected virtual void OnSprintPressed (InputAction.CallbackContext context) {
        stateMachine.ChangeState (player.StateSprinting);
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
        player.Motor.HandleLocomotion (movementInput , speed);
    }
}
