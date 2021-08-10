using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Motor))]
[RequireComponent (typeof (CharacterController))]
public abstract class Pawn : MonoBehaviour {
    public StateMachine StateMachine { get; protected set; }
    public Motor Motor { get; protected set; }
    public CharacterController CharacterController { get; protected set; }

    protected State defaultState;

    protected virtual void Awake () {
        StateMachine = new StateMachine ();
        CharacterController = GetComponent<CharacterController> ();
        Motor = GetComponent<Motor> ();
        InitializeStates ();
    }

    protected virtual void Start () {
        StateMachine.Initialize (defaultState);
    }

    protected virtual void Update () {
        StateMachine.Tick ();
    }

    protected virtual void InitializeStates () {
    }
}
