using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectList : MonoBehaviour
{
    [SerializeField] private List<GameObject> listGameObject;
    [SerializeField] private Vector3 originPosition;
    [SerializeField] private SimulationData simulationData;
    [SerializeField] private float moveTime;

    private Coroutine movingCoroutine;

    public void MoveEveryObjectToTarget()
    {
        StopAllCoroutines();
        for (int i = 0; i < listGameObject.Count; i++)
        {
            StartCoroutine(MoveTo(listGameObject[i].transform, listGameObject[i].transform.localPosition, simulationData.planeXZCenterWithOnGravity));
        }
    }

    public void MoveEveryObjectToOrigin()
    {
        StopAllCoroutines();
        for (int i = 0; i < listGameObject.Count; i++)
        {
            StartCoroutine(MoveTo(listGameObject[i].transform, listGameObject[i].transform.localPosition, originPosition));
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
