using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingObject : MonoBehaviour
{
    [SerializeField] Transform targetObject;
    void FixedUpdate()
    {
        transform.localPosition = targetObject.localPosition;
    }
}
