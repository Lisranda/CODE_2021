using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (CharacterController))]
public abstract class Pawn : MonoBehaviour {
    public CharacterController CharacterController { get; protected set; }
    public StateMachine StateMachine { get; protected set; }
    public Attributes Attributes { get; protected set; }

    protected Motor motor;
    protected State defaultState;
    protected float gravityMagnitude;
    protected Vector3 movementInput;
    protected Vector3 movementVelocity;
    protected Quaternion rotationInput;
    protected float currentSpeed;

    protected const float groundedGravity = -50f;
    protected const float fallingGravity = -9.8f;
    protected bool groundedLastFrame = true;

    protected virtual void Awake () {
        CharacterController = GetComponent<CharacterController> ();
        StateMachine = new StateMachine ();
        Attributes = new Attributes ();
        motor = new Motor (this);

        InitializeStates ();
    }

    protected virtual void Start () {
        if (defaultState != null) StateMachine.Initialize (defaultState);
    }

    protected virtual void Update () {
        StateMachine.Tick ();
        ProcessFrameMovement ();
        motor.HandleRotation (rotationInput);
        motor.HandleLocomotion (movementVelocity);
    }

    protected virtual void InitializeStates () {
    }

    public void SetMovementDirection (Vector3 direction) => movementInput = direction;
    public void SetTargetRotation (Quaternion rotation) => rotationInput = rotation;
    public void SetCurrentSpeed (float speed) => currentSpeed = speed;

    protected void ProcessFrameMovement () {
        movementVelocity.x = movementInput.x * currentSpeed;
        movementVelocity.z = movementInput.y * currentSpeed;

        if (CharacterController.isGrounded) {
            if (CharacterController.SlopeAngle () > 90f) movementVelocity.y = 0f;
            else movementVelocity.y = groundedGravity;
            groundedLastFrame = true;
        } else {
            if (groundedLastFrame) {
                movementVelocity.y = 0f;
                groundedLastFrame = false;
            }
            movementVelocity.y += fallingGravity * Time.deltaTime;
        }
    }    
}
