using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveObject : MonoBehaviour
{
    [SerializeField] protected float moveTime;
    [SerializeField] public Vector3Variable vector3Binded;
    private bool objectIsMoving = false;

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
            SetVector3Bind();
            yield return null;
        }

        transform.localPosition = endPosition;
        SetVector3Bind();
        objectIsMoving = false;
    }

    private void SetVector3Bind()
    {
        if (vector3Binded == null)
        {return;}

        vector3Binded.Value = transform.localPosition;
    }
}
