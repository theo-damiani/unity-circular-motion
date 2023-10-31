using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconBtnManager : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Button button;

    void Start()
    {
        SetNotInteractable();
    }

    public void SetReverseInteractable(bool value)
    {
        if (value)
        {
            SetNotInteractable();
        }
        else
        {
            SetInteractable();
        }
    }

    public void SetNotInteractable()
    {
        button.interactable = false;
        image.color = Color.gray;
    }

    public void SetInteractable()
    {
        button.interactable = true;
        image.color = Color.red;
    }
}
