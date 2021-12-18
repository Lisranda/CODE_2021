using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PCFalling : PCAnyState {
    public PCFalling (StateMachine stateMachine , Player player) : base (stateMachine , player) {
    }

    public override void OnEnter () {
        base.OnEnter ();
    }

    public override void OnExit () {
        base.OnExit ();
    }

    public override void Tick () {
        base.Tick ();
    }

    public override void FixedTick () {
        base.FixedTick ();
    }
}
