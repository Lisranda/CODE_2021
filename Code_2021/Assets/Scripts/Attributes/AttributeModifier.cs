using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttributeModifierType {
    Flat,
    Percent
}

public class AttributeModifier {
    public readonly AttributeModifierType ModifierType;
    public readonly float Value;
    public readonly object Source;

    public AttributeModifier (AttributeModifierType modifierType , float value , object source) {
        ModifierType = modifierType;
        Value = value;
        Source = source;
    }

    public AttributeModifier (AttributeModifierType modifierType , float value) : this (modifierType , value , null) { }
}
