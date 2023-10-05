using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Variable", menuName = "Variables / Vector3")]
public class Vector3Variable : ScriptableObject
{
    [SerializeField] private Vector3 _value; 
    [SerializeField] private GameEvent OnUpdateEvent;

    public Vector3 Value 
    {
        get {return _value;}

        set
        {
            _value = value;
            if (OnUpdateEvent)
                OnUpdateEvent.Raise();
        }
    }
}
