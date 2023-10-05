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
        cylinder.transform.localScale = new Vector3(0.3f, simulationData.PlaneCurrentPosition.y/2+0.1f, 0.3f);
        cylinder.transform.localPosition = new Vector3(0f, simulationData.PlaneCurrentPosition.y/2+0.1f, 0f);
        cylinder.SetActive(true);
    }

    public void SetRope()
    {
        rope.transform.localPosition = new Vector3(0f, simulationData.PlaneCurrentPosition.y, 0f);
        
        rope.transform.rotation = Quaternion.identity;
        rope.transform.Rotate(
            Quaternion.LookRotation(ball.transform.localPosition-rope.transform.localPosition).eulerAngles
        );
        //rope.transform.LookAt(ball.transform);
        ropeData.RopeLength = (rope.transform.localPosition - ball.transform.localPosition).magnitude;
        rope.gameObject.SetActive(true);
    }
}
