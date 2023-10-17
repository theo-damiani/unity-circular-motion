using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class MotionData
{
    public Motion motion;
    public bool isActive;
}

[RequireComponent(typeof(Rigidbody))]
public class MotionManager : MonoBehaviour
{
    [SerializeField] private MotionData[] listMotionData;
    [SerializeField] private bool enableMotion = false;
    private int currentMotionIndex;

    void Start()
    {
        for (int i = 0; i < listMotionData.Length; i++)
        {
            listMotionData[i].motion.isMotionInit = false;
        }
    }

    void FixedUpdate()
    {
        if (enableMotion)
        {
            for (int i = 0; i < listMotionData.Length; i++)
            {
                if (listMotionData[i].isActive)
                {
                    listMotionData[i].motion.ApplyMotion(GetComponent<Rigidbody>());
                }
            }
        }
    }

    public void SetAndApplyMotionIndex(int index)
    {
        if (index >= listMotionData.Length)
        {return;}

        currentMotionIndex = index;

        for (int i = 0; i < listMotionData.Length; i++)
        {
            if (i==index)
            {
                listMotionData[i].motion.InitMotion();
                listMotionData[i].isActive = true;
            }
            else
            {
                listMotionData[i].isActive = false;
            }
        }
    }

    public void StopMotionIndex(int index)
    {
        if (index >= listMotionData.Length)
        {return;}

        listMotionData[index].isActive = false;
    }

    public void StopAllMotion()
    {
        for (int i = 0; i < listMotionData.Length; i++)
        {
            listMotionData[i].isActive = false;
        }
    }

    public void EnableMotion()
    {
        listMotionData[currentMotionIndex].motion.InitMotion();
        enableMotion = true;
    }

    public void DisableMotion()
    {
        enableMotion = false;
    }
}
