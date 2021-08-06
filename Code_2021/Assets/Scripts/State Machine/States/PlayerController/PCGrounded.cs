using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PCGrounded : PCAnyState {
    protected Vector2 movementInput;
    protected Quaternion targetRotation;

    public delegate void RotationDelegate (Quaternion rotation);
    public delegate void LocomotionDelegate (LocomotionContext locomotion);
    public event RotationDelegate RotationCallback;
    public event LocomotionDelegate LocomotionCallback;

    public class LocomotionContext : EventArgs {
        public Vector2 MovementInput { get; protected set; }
        public State SendingState { get; protected set; }

        public LocomotionContext (Vector2 movementInput, State sendingState) {
            this.MovementInput = movementInput;
            this.SendingState = sendingState;
        }
    }

    public PCGrounded (StateMachine stateMachine , Player player) : base (stateMachine , player) {
        this.stateMachine = stateMachine;
        this.player = player;
        this.cam = Camera.main;
        this.transform = player.transform;
        this.playerInput = player.PlayerInput;
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
        playerInput.CharacterInput.Walk.started += OnWalkPressed;
        playerInput.CharacterInput.Sprint.started += OnSprintPressed;
    }

    protected virtual void DeregisterCallbacks () {
        playerInput.CharacterInput.Walk.started -= OnWalkPressed;
        playerInput.CharacterInput.Sprint.started -= OnSprintPressed;
    }

    protected virtual void OnWalkPressed (InputAction.CallbackContext context) {
        player.ToggleWalking ();
    }

    protected virtual void OnSprintPressed (InputAction.CallbackContext context) {
        stateMachine.ChangeState (player.StateSprinting);
    }

    protected virtual void FaceMouseInput () {
        Plane normalPlane = new Plane (Vector3.up , transform.position);
        Ray ray = cam.ScreenPointToRay (playerInput.CharacterInput.Cursor.ReadValue<Vector2> ());
        if (normalPlane.Raycast (ray , out float hitDistance)) {
            Vector3 hitPoint = ray.GetPoint (hitDistance);
            targetRotation = Quaternion.LookRotation (hitPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
        }
        RotationCallback?.Invoke (targetRotation);
    }

    protected virtual void Locomotion () {
        Vector2 movementInput = playerInput.CharacterInput.Locomotion.ReadValue<Vector2> ();
        LocomotionContext locomotionContext = new LocomotionContext (movementInput , this);
        LocomotionCallback?.Invoke (locomotionContext);
    }
}
