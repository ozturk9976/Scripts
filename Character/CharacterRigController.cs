using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;


public class CharacterRigController : MonoBehaviour
{
    public TwoBoneIKConstraint LeftHandIkConstraint;
    public TwoBoneIKConstraint RightHandIkConstraint;
    public MultiAimConstraint ChestIkConstraint;

    public static CharacterRigController instance;

    private void Awake()
    {
        instance = this;
    }

    public void SetWeight(MultiAimConstraint constraint,float targetWeight)
    {
        constraint.weight = targetWeight;
    }
}
