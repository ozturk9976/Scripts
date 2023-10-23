using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetForIK : MonoBehaviour
{
    [SerializeField] float targetLerpSpeed;

    private Vector3 offset = new Vector3(0,0,2);
    private void LateUpdate()
    {
        Transform targetPos = STREAMING_DATA.CHARACTER_TRANSFORM;
        Vector3 targetVect = (targetPos.position + targetPos.transform.forward * 2 + targetPos.transform.up * 1.4f);
        transform.position = Vector3.Lerp(transform.position, targetVect, targetLerpSpeed);
    }
}
