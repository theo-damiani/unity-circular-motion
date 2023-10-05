using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectList : MonoBehaviour
{
    [SerializeField] private List<GameObject> listGameObject;
    [SerializeField] private List<Vector3> originPositions;
    [SerializeField] private SimulationData simulationData;
    [SerializeField] private float moveTime;

    private Coroutine movingCoroutine;

    public void MoveEveryObjectToTarget()
    {
        StopAllCoroutines();
        for (int i = 0; i < listGameObject.Count; i++)
        {
            Vector3 targetPos = simulationData.planeXZCenterWithOnGravity;
            if (i!=0)
            {
                //targetPos += new Vector3(2,0,0);
            }
            StartCoroutine(MoveTo(listGameObject[i].transform, listGameObject[i].transform.localPosition, targetPos));
        }
    }

    public void MoveEveryObjectToOrigin()
    {
        StopAllCoroutines();
        for (int i = 0; i < listGameObject.Count; i++)
        {
            StartCoroutine(MoveTo(listGameObject[i].transform, listGameObject[i].transform.localPosition, originPositions[i]));
        }
    }

    private IEnumerator MoveTo(Transform goTransform, Vector3 startPosition, Vector3 endPosition)
    {
        float time = 0;

        while (time < moveTime)
        {
            time += Time.deltaTime;
            float t = time / moveTime;
            t = t * t * (3f - 2f * t);
            goTransform.localPosition = Vector3.Slerp(startPosition, endPosition, t);
            simulationData.PlaneXZCurrentPosition = goTransform.localPosition;

            yield return null;
        }

        goTransform.localPosition = endPosition;
        simulationData.PlaneXZCurrentPosition = endPosition;
    }
}
