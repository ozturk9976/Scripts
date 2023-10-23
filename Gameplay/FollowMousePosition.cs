using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMousePosition : MonoBehaviour
{
    void Update()
    {
        transform.position = STREAMING_DATA.MOUSE_POSITION;
    }
}
