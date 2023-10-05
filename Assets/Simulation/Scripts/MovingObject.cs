using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectList : MonoBehaviour
{
    [SerializeField] private List<GameObject> listGameObject;
    [SerializeField] private float originY;
    [SerializeField] private SimulationData simulationData;
    [SerializeField] private float moveTime;

    private Coroutine movingCoroutine;

    public void MoveEveryObjectToTarget()
    {
        StopAllCoroutines();
        for (int i = 0; i < listGameObject.Count; i++)
        {
            Vector3 targetPos = new Vector3(listGameObject[i].transform.localPosition.x,
                 simulationData.YCenterWithOnGravity,
                 listGameObject[i].transform.localPosition.z);
            StartCoroutine(MoveTo(listGameObject[i].transform, listGameObject[i].transform.localPosition, targetPos));
        }
    }

    public void MoveEveryObjectToOrigin()
    {
        StopAllCoroutines();
        for (int i = 0; i < listGameObject.Count; i++)
        {
            Vector3 targetPos = new Vector3(listGameObject[i].transform.localPosition.x, originY, listGameObject[i].transform.localPosition.z);
            StartCoroutine(MoveTo(listGameObject[i].transform, listGameObject[i].transform.localPosition, targetPos));
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
            goTransform.localPosition = Vector3.Lerp(startPosition, endPosition, t);
            simulationData.PlaneXZCurrentPosition = goTransform.localPosition;

            yield return null;
        }

        goTransform.localPosition = endPosition;
        simulationData.PlaneXZCurrentPosition = endPosition;
    }
}
