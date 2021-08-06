using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {
    public PlayerInput PlayerInput { get; private set; }
    public StateMachine StateMachine { get; private set; }

    public PCWalking StateWalking { get; private set; }
    public PCRunning StateRunning { get; private set; }
    public PCSprinting StateSprinting { get; private set; }

    public bool rememberWalking { get; private set; }

    public void ToggleWalking () { rememberWalking = !rememberWalking; }

    void Awake () {
        PlayerInput = new PlayerInput ();
        PlayerInput.CharacterInput.Enable ();

        StateMachine = new StateMachine ();
        InitializeStates ();
    }

    void Start () {
        StateMachine.Initialize (StateRunning);
    }

    void Update () {
        StateMachine.Tick ();
    }

    void InitializeStates () {
        StateWalking = new PCWalking (StateMachine , this);
        StateRunning = new PCRunning (StateMachine , this);
        StateSprinting = new PCSprinting (StateMachine , this);
    }

}
