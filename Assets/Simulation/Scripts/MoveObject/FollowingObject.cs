using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingObject : MonoBehaviour
{
    [SerializeField] Transform targetObject;
    void LateUpdate()
    {
        transform.localPosition = targetObject.localPosition;
    }
}
