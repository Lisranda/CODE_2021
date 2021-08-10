using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections.ObjectModel;

public class Attribute {
    public float BaseValue { get; private set; }

    public float Value {
        get {
            if (isDirty) {
                storedValue = CalculateFinalValue ();
                isDirty = false;
            }
            return storedValue;
        }
    }

    public readonly ReadOnlyCollection<AttributeModifier> FlatModifiers;
    public readonly ReadOnlyCollection<AttributeModifier> PercentModifiers;

    private readonly List<AttributeModifier> flatModifiers;
    private readonly List<AttributeModifier> percentModifiers;
    private bool isDirty = true;
    private float storedValue;

    public Attribute () {
        flatModifiers = new List<AttributeModifier> ();
        percentModifiers = new List<AttributeModifier> ();
        FlatModifiers = flatModifiers.AsReadOnly ();
        PercentModifiers = percentModifiers.AsReadOnly ();
    }

    public Attribute (float baseValue) : this () {
        BaseValue = baseValue;
    }

    public void AddModifier (AttributeModifier modifier) {
        isDirty = true;
        if (modifier.ModifierType == AttributeModifierType.Flat) flatModifiers.Add (modifier);
        else if (modifier.ModifierType == AttributeModifierType.Percent) percentModifiers.Add (modifier);
    }

    public bool RemoveModifier (AttributeModifier modifier) {
        if (modifier.ModifierType == AttributeModifierType.Flat) return isDirty = flatModifiers.Remove (modifier);
        if (modifier.ModifierType == AttributeModifierType.Percent) return isDirty = percentModifiers.Remove (modifier);
        return false;
    }

    public bool RemoveModifiersFromSource (object source) {
        bool removed = false;

        void Process (List<AttributeModifier> toProcess) {
            for (int i = toProcess.Count - 1 ; i >= 0 ; i--) {
                if (toProcess [i].Source == source) {
                    isDirty = true;
                    removed = true;
                    toProcess.RemoveAt (i);
                }
            }
        }

        Process (flatModifiers);
        Process (percentModifiers);
        return removed;
    }

    public float CalculateFinalValue () {
        float finalValue = BaseValue;

        foreach (AttributeModifier modifier in flatModifiers) {
            finalValue += modifier.Value;
        }

        float storeValue = finalValue;

        foreach (AttributeModifier modifier in percentModifiers) {
            finalValue += (storeValue * modifier.Value);
        }

        return (float)Math.Round (finalValue , 2);
    }
}