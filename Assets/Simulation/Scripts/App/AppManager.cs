using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class AppManager : MonoBehaviour
{
    [SerializeField] private BoolVariable simIsPaused;
    [SerializeField] private Vector3Variable ballVelocity;
    void Start()
    {
        InitApp();
    }

    private void InitApp()
    {
        // Main Application setup
        simIsPaused.Value = true;
        ballVelocity.Value = new Vector3(2,0,-2);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
