using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine {
    protected State currentState;

    public StateMachine () { }

    public void Initialize (State initialState) {
        currentState = initialState;
        currentState.OnEnter ();
    }

    public void ChangeState (State newState) {
        if (currentState == newState) return;
        if (currentState != null) currentState.OnExit ();

        currentState = newState;

        if (currentState != null) {
            currentState.OnEnter ();
            currentState.Tick ();
        }
    }

    public void Tick () { currentState.Tick (); }
    public void FixedTick () { currentState.FixedTick (); }
}
