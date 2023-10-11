using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody), typeof(MotionManager))]
public class GravityManager : MonoBehaviour
{
    [SerializeField] private MotionManager motion; // The motion is predominant over gravity
    [SerializeField] private GameEvent OnEnableGravity;
    [SerializeField] private GameEvent OnDisableGravity;

    void Start()
    {
        GameEventListener gameEventListener = gameObject.AddComponent<GameEventListener>();
        gameEventListener.Event = OnEnableGravity;
        UnityEvent unityEvent = new();
        unityEvent.AddListener(EnableGravity);
        gameEventListener.Response = unityEvent;

        GameEventListener gel2 = gameObject.AddComponent<GameEventListener>();
        gel2.Event = OnDisableGravity;
        UnityEvent ue2 = new();
        ue2.AddListener(DisableGravity);
        gel2.Response = unityEvent;
    }

    public void EnableGravity()
    {
        if (motion.isActiveAndEnabled)
        {
            return;
        }
        GetComponent<Rigidbody>().useGravity = true;
    }

    public void DisableGravity()
    {
        if (motion.isActiveAndEnabled)
        {
            return;
        }
        GetComponent<Rigidbody>().useGravity = true;
    }
}
