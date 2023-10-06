using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveObject : MonoBehaviour
{
    [SerializeField] private float moveTime;
    private bool objectIsMoving;

    public void MoveTo(Vector3 startPosition, Vector3 endPosition)
    {
        if (objectIsMoving)
        {
            StopAllCoroutines();
        }
        StartCoroutine(CoroutineMoveTo(startPosition, endPosition));
    }

    private IEnumerator CoroutineMoveTo(Vector3 startPosition, Vector3 endPosition)
    {
        objectIsMoving = true;

        float time = 0;

        while (time < moveTime)
        {
            time += Time.deltaTime;
            float t = time / moveTime;
            t = t * t * (3f - 2f * t);
            transform.localPosition = Vector3.Lerp(startPosition, endPosition, t);

            yield return null;
        }

        transform.localPosition = endPosition;
        objectIsMoving = false;
    }
}
