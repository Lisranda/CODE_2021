using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCAnyState : State {
    protected Player player;

    public PCAnyState (StateMachine stateMachine, Player player) : base (stateMachine) {
        this.player = player;
    }

    public override void OnEnter () { base.OnEnter (); }
    public override void OnExit () { base.OnExit (); }
    public override void Tick () { base.Tick (); }
    public override void FixedTick () { base.FixedTick (); }
}
