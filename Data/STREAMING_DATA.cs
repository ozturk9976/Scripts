using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class STREAMING_DATA : MonoBehaviour
{
    public static Vector3 MOUSE_POSITION;

    private static Transform _CHARACTER_TRANSFORM;


    public static STREAMING_DATA instance;
    private static PlayerInputActionAsset playerInput;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        MOUSE_POSITION = RaycastMousePosition();
    }
   
    public static Vector3 RaycastMousePosition()
    {
        Vector2 mousePosition =INPUT_MANAGER.playerInput.Player.character_look_position.ReadValue<Vector2>();
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 lookPosition = new Vector3(hit.point.x,0.75f, hit.point.z);
            return lookPosition;
        }
        else return _CHARACTER_TRANSFORM.forward;
    }

    public static Transform CHARACTER_TRANSFORM
    {
        get { return _CHARACTER_TRANSFORM; }
        set { _CHARACTER_TRANSFORM = value; }
    }

}
