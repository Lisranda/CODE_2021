using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Pawn {
    public Camera Cam { get; protected set; }
    public PlayerInput PlayerInput { get; protected set; }

    public PCWalking StateWalking { get; protected set; }
    public PCRunning StateRunning { get; protected set; }
    public PCSprinting StateSprinting { get; protected set; }
    public PCSlipping StateSlipping { get; protected set; }
    public PCFalling StateFalling { get; protected set; }

    public bool RememberWalking { get; protected set; }

    protected RaycastHit groundHit;

    public virtual void ToggleWalking () { RememberWalking = !RememberWalking; }

    protected override void Awake () {
        base.Awake ();
        Cam = Camera.main;
        PlayerInput = new PlayerInput ();
        PlayerInput.CharacterInput.Enable ();
    }

    protected override void Start () {
        base.Start ();
    }

    protected override void Update () {
        base.Update ();
        Debug.Log (CharacterController.isGrounded + " | " + CharacterController.SureFooted () + " | " + CharacterController.SlopeAngle ());
    }

    protected override void InitializeStates () {
        base.InitializeStates ();
        StateWalking = new PCWalking (StateMachine , this);
        StateRunning = new PCRunning (StateMachine , this);
        StateSprinting = new PCSprinting (StateMachine , this);
        StateSlipping = new PCSlipping (StateMachine , this);
        StateFalling = new PCFalling (StateMachine , this);
        defaultState = StateRunning;
    }
}
