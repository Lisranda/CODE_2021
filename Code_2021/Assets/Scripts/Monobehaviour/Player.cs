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

    public bool RememberWalking { get; protected set; }

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
    }

    protected override void InitializeStates () {
        base.InitializeStates ();
        StateWalking = new PCWalking (StateMachine , this);
        StateRunning = new PCRunning (StateMachine , this);
        StateSprinting = new PCSprinting (StateMachine , this);
        defaultState = StateRunning;
    }

}
