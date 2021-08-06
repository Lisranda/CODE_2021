using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {
    public PlayerInput PlayerInput { get; private set; }
    public StateMachine StateMachine { get; private set; }

    public PCGrounded StateGrounded { get; private set; }

    void Awake () {
        PlayerInput = new PlayerInput ();
        PlayerInput.CharacterInput.Enable ();

        StateMachine = new StateMachine ();
        InitializeStates ();
    }

    void Start () {
        StateMachine.Initialize (StateGrounded);
    }

    void Update () {
        StateMachine.Tick ();
    }

    void InitializeStates () {
        StateGrounded = new PCGrounded (StateMachine , this);
    }
}
