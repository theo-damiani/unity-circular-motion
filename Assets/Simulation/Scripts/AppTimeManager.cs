using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TimeMode
{
    Normal,
    UnscaledTime
}

public static class AppTimeUtils
{
    public static float GetFixedDeltaTime(TimeMode mode)
    {
        if (mode == TimeMode.Normal)
        {
            return Time.fixedDeltaTime;
        }
        else
        {
            return Time.fixedUnscaledDeltaTime;
        }
    }

    public static float GetDeltaTime(TimeMode mode)
    {
        if (mode == TimeMode.Normal)
        {
            return Time.deltaTime;
        }
        else
        {
            return Time.unscaledDeltaTime;
        }
    }
}
public class AppTimeManager : MonoBehaviour
{
    public void PauseTime()
    {
        Time.timeScale = 0f;
    }

    public void ResumeTime()
    {
        Time.timeScale = 1f;
    }
}
