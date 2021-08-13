using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PCSprinting : PCAnyState {
    public PCSprinting (StateMachine stateMachine , Player player) : base (stateMachine , player) {
    }

    public override void OnEnter () {
        base.OnEnter ();
    }

    public override void OnExit () {
        base.OnExit ();
    }

    public override void Tick () {
        base.Tick ();
        PollSprinting ();
    }

    public override void FixedTick () {
        base.FixedTick ();
    }

    protected override void Locomotion () {
        speed = player.Attributes.SprintSpeed.Value;
        base.Locomotion ();
    }

    protected override void PollSprinting () {
        if (player.PlayerInput.CharacterInput.Sprint.ReadValue<float> () == 0) stateMachine.ChangeState (player.StateRunning);
    }
}
