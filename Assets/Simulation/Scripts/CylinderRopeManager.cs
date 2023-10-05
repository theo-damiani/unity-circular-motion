using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderRopeManager : MonoBehaviour
{
    [SerializeField] private GameObject cylinder;
    [SerializeField] private GameObject ball;
    [SerializeField] private Rope rope;
    [SerializeField] private RopeData ropeData;
    [SerializeField] private SimulationData simulationData;
    // Start is called before the first frame update
    void Start()
    {
        cylinder.SetActive(false);
        rope.gameObject.SetActive(false);
    }

    public void SetCylinder()
    {
        cylinder.transform.localScale = new Vector3(0.3f, simulationData.planeXZCenterWithOnGravity.y/2+0.1f, 0.3f);
        cylinder.transform.localPosition = new Vector3(0f, simulationData.planeXZCenterWithOnGravity.y/2+0.1f, 0f);
        cylinder.SetActive(true);
    }

    public void SetRope()
    {
        rope.transform.localPosition = new Vector3(0f, simulationData.planeXZCenterWithOnGravity.y, 0f);
        ropeData.RopeDirectionInit = Quaternion.LookRotation((rope.transform.localPosition - ball.transform.localPosition).normalized).eulerAngles.normalized;
        ropeData.RopeLength = (rope.transform.localPosition - ball.transform.localPosition).magnitude;
        rope.gameObject.SetActive(true);
    }
}
