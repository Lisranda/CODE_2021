using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PCRunning : PCAnyState {

    public PCRunning (StateMachine stateMachine , Player player) : base (stateMachine , player) {
    }

    public override void OnEnter () {
        base.OnEnter ();        
    }

    public override void OnExit () {
        base.OnExit ();
    }

    public override void Tick () {
        base.Tick ();
        player.SetCurrentSpeed (player.Attributes.Speed.Value);
    }

    public override void FixedTick () {
        base.FixedTick ();
    }    
}
