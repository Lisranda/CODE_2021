using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes {
    public Attribute Speed { get; }
    public Attribute WalkSpeed { get; }
    public Attribute SprintSpeed { get; }
    public Attribute RotationSpeed { get; }
    public Attribute FallControlSpeed { get; }

    public Attributes () {
        Speed = new Attribute (5f);
        WalkSpeed = new Attribute (3f);
        SprintSpeed = new Attribute (10f);
        RotationSpeed = new Attribute (7f);
        FallControlSpeed = new Attribute (1f);
    }
}
