using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCAnyState : State {
    protected Player player;
    protected Camera cam;
    protected Transform transform;
    protected PlayerInput playerInput;

    public PCAnyState (StateMachine stateMachine, Player player) : base (stateMachine) {
        this.stateMachine = stateMachine;
        this.player = player;
        this.cam = Camera.main;
        this.transform = player.transform;
        this.playerInput = player.PlayerInput;
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
