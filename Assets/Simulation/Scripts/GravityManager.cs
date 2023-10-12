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
    private bool motionIsActive = false;
    private bool gravityIsActive = false;

    public bool ComputeGravityBool()
    {
        return gravityIsActive & (!motionIsActive);
    }

    public void MotionIsActive()
    {
        motionIsActive = true;
        GetComponent<Rigidbody>().useGravity = ComputeGravityBool();
    }

    public void MotionIsInactive()
    {
        motionIsActive = false;
        GetComponent<Rigidbody>().useGravity = ComputeGravityBool();
    }

    public void GravityIsActive()
    {
        gravityIsActive = true;
        GetComponent<Rigidbody>().useGravity = ComputeGravityBool();
    }

    public void GravityIsInactive()
    {
        gravityIsActive = false;
        GetComponent<Rigidbody>().useGravity = ComputeGravityBool();
    }
}
