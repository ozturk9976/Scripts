using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(CharacterRigController))]
public class Character : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private CharacterRigController characterRigController;

    [Header("Character settings")]
    [SerializeField] private float gravity = -9.81f;


    //Debug Reasons
    private Vector3 mouseLookGizmoPos;
    //
    [SerializeField] float rotationSpeed = 1.0f;
    [SerializeField] float playerSpeed = 2.0f;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    //Animation bools
    [SerializeField] Animator animator;
    private string currentState;
    private bool isWalking;


    const string IDLE = "Idle";
    const string WALKING = "Walking";
    const string LEFT_STRAFE_WALKING = "WalkingLeft";
    const string RIGHT_STRAFE_WALKING = "WalkingRight";


    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        STREAMING_DATA.CHARACTER_TRANSFORM = transform;

        LookAtMousePosition();


        Vector3 move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        move.y += gravity * Time.deltaTime;
        controller.Move(move * Time.deltaTime * playerSpeed);





        /*
        if (Input.GetAxis("Vertical") != 0)
        {
            SetAnimationState(WALKING);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            SetAnimationState(RIGHT_STRAFE_WALKING);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            SetAnimationState(LEFT_STRAFE_WALKING);
        }
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            SetAnimationState(IDLE);
        }
        */
    }

    private void LookAtMousePosition() 
    {
        Vector3 lookVect = STREAMING_DATA.MOUSE_POSITION;
        
        if (Vector3.Distance(transform.position,lookVect) <= 1) 
        {
            Debug.Log("Z");
            return;
        }
        
        Quaternion lookQuat = Quaternion.LookRotation(lookVect - transform.position, Vector3.up).normalized;
        this.transform.rotation = Quaternion.Slerp(transform.rotation, lookQuat, rotationSpeed * Time.fixedDeltaTime);
    }

    private void SetAnimationState(string newState)
    {
        if (newState == currentState) 
        {
            return;
        }
        animator.Play(newState);
        currentState = newState;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(mouseLookGizmoPos, 1);
    }
}
