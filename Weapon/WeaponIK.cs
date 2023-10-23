using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

[RequireComponent(typeof(RigTransform))]
public class WeaponIK : MonoBehaviour
{
    [SerializeField] private Transform leftHand;
    [SerializeField] private Transform rightHand;

    private void Awake()
    {
        SetHandIKs();
    }
    public void SetHandIKs() 
    {
        CharacterRigController.instance.LeftHandIkConstraint.data.target = leftHand;
        CharacterRigController.instance.RightHandIkConstraint.data.target = rightHand;
    }
}
