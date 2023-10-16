using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TrailRenderer trailRenderer;
        if(!TryGetComponent<TrailRenderer>(out trailRenderer))
        {
            trailRenderer = gameObject.AddComponent<TrailRenderer>();
        }
        // Trail Renderer On:
        trailRenderer.autodestruct = false;
        trailRenderer.enabled = true;
        //trailRenderer.time = float.PositiveInfinity;
        trailRenderer.time = 5f;
        AnimationCurve curve = new AnimationCurve();
        float curveWidth = 0.1f;
        curve.AddKey(0f, curveWidth);
        curve.AddKey(1f, curveWidth);
        trailRenderer.widthCurve = curve;

        //DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
