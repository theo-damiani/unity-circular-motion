using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ActiveManager : MonoBehaviour
{
    [SerializeField] List<GameObject> listOfGameObjects;
    
    public void ActiveObjectsAtIndex(int index)
    {

        for (int i = 0; i < listOfGameObjects.Count; i++)
        {
            if (i == index)
            {
                listOfGameObjects[i].SetActive(true);
            }
            else
            {
                listOfGameObjects[i].SetActive(false);
            }
        }
    }

    public void DeActiveAll()
    {
        for (int i = 0; i < listOfGameObjects.Count; i++)
        {
            listOfGameObjects[i].SetActive(false);
        }
    }
}
