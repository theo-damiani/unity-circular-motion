using UnityEngine;

/// <summary>
///     The GravityManager is responsible of setting correctly the useGravity boolean of the Rigidbody.
///     But the motion associated to the events given in attributes is predominant over the gravity GameEvent.
///     Therefore, the useGravity should follow the table below:
///     
///     | gravityEvent | motionEvent |      | useGravity |
///     | ------------ | ----------- |      | ---------- |
///     |      0       |      0      |      |      0     |
///     |      0       |      1      |      |      0     |
///     |      1       |      0      |      |      1     |
///     |      1       |      1      |      |      0     |
///     
///     useGravity = gravityEvent & not(motionEvent)
/// </summary>

[RequireComponent(typeof(Rigidbody))]
public class GravityManager : MonoBehaviour
{
    [SerializeField] private BoolReference motionIsActive;
    [SerializeField] private BoolReference gravityIsActive;

    public bool ComputeGravityBool()
    {
        return gravityIsActive.Value & (!motionIsActive.Value);
    }

    void OnEnable()
    {
        motionIsActive.Variable.OnUpdateValue += UpdateGravity;
        gravityIsActive.Variable.OnUpdateValue += UpdateGravity;
    }

    void OnDisable()
    {
        motionIsActive.Variable.OnUpdateValue -= UpdateGravity;
        gravityIsActive.Variable.OnUpdateValue -= UpdateGravity;
    }

    public void UpdateGravity()
    {
        GetComponent<Rigidbody>().useGravity = ComputeGravityBool();
    }
}
