using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] private Vector3 originPosition;
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private float moveTime;

    private Coroutine movingCoroutine;

    public void MoveObjectToTarget()
    {
        if (movingCoroutine!=null)
            StopCoroutine(movingCoroutine);
        movingCoroutine = StartCoroutine(MoveTo(transform.localPosition, targetPosition));
    }

    public void MoveObjectToOrigin()
    {
        if (movingCoroutine!=null)
            StopCoroutine(movingCoroutine);
        movingCoroutine = StartCoroutine(MoveTo(transform.localPosition, originPosition));
    }

    private IEnumerator MoveTo(Vector3 startPosition, Vector3 endPosition)
    {
        float time = 0;

        while (time < moveTime)
        {
            time += Time.deltaTime;
            float t = time / moveTime;
            t = t * t * (3f - 2f * t);
            transform.localPosition = Vector3.Slerp(startPosition, endPosition, t);

            yield return null;
        }

        transform.localPosition = endPosition;
    }
}
