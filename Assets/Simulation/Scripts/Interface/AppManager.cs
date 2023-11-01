using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class AppManager : Singleton<AppManager>
{
    [Header("Affordances")]
    [SerializeField] private Affordances defaultAffordances;
    private Affordances currentAffordances;

    [Header("Camera")]
    [SerializeField] private CameraManager mainCamera;
    [SerializeField] private RectTransform cameraControls;
    [SerializeField] private RectTransform cameraZoomSlider;

    [Header("Main App Controls")]
    [SerializeField] private RectTransform playButton;
    [SerializeField] private RectTransform resetButton;

    [Header("ball Variables")]
    [SerializeField] private GameObject ball;
    [SerializeField] private BoolVariable ballIsInteractive;
    [SerializeField] private Vector3Variable ballVelocity;
    [SerializeField] private GameObject ballVelocityVector;
    [SerializeField] private BoolVariable showVelocityEquation;
    [SerializeField] private GameObject velocityLabel;
    [SerializeField] private BoolVariable showBallPath;
    [SerializeField] private RectTransform showBallPathToggle;

    [Header("Gravity force Variables")]
    [SerializeField] private GameEvent gravityIsOn;
    [SerializeField] private GameEvent gravityIsOff;
    [SerializeField] private BoolVariable gravityIsActive;
    [SerializeField] private RectTransform gravityIsInteractive;
    [SerializeField] private BoolVariable showGravityField;
    [SerializeField] private GameObject gravityLabel;
    [SerializeField] private BoolVariable showGravityEquation;

    [Header("Central force Variables")]
    [SerializeField] private BoolVariable centralForceIsActive;
    [SerializeField] private BoolVariable centralForceIsInteractive;
    [SerializeField] private Vector3Variable angularVelocity;
    [SerializeField] private BoolVariable showCentralVector;
    [SerializeField] private GameObject showCentralLabel;
    [SerializeField] private BoolVariable showCentralEquation;

    [Header("Extra")]
    [SerializeField] private GameObject referenceFrame;

    void Start()
    {
        #if UNITY_EDITOR == true
            currentAffordances = Instantiate(defaultAffordances);
            ResetApp();
        #endif

        #if !UNITY_EDITOR && UNITY_WEBGL
            // disable WebGLInput.captureAllKeyboardInput so elements in web page can handle keyboard inputs
            WebGLInput.captureAllKeyboardInput = false;
        #endif
    }

    public void ResetAppFromJSON(string affordanceJson)
    {
        currentAffordances = Instantiate(defaultAffordances);
        JsonUtility.FromJsonOverwrite(affordanceJson, currentAffordances);
        ResetApp();
    }

    public void ResetApp()
    {
        // // Main control config:
        playButton.gameObject.SetActive(currentAffordances.showPlayButton);
        playButton.GetComponent<PlayButton>().PlayWithoutNotify();
        resetButton.gameObject.SetActive(currentAffordances.showResetButton);
        // // ball config:
        ball.transform.SetPositionAndRotation(currentAffordances.physicalObject.initialPosition.ToVector3(), Quaternion.identity);
        // ball.transform.Find("ballObject").transform.rotation = Quaternion.Euler(currentAffordances.physicalObject.initialRotation.ToVector3());
        ballVelocity.Value = currentAffordances.physicalObject.initialVelocity.ToVector3();
        ballVelocityVector.SetActive(currentAffordances.physicalObject.showVelocityVector);
        ballVelocityVector.GetComponent<DraggableVector>().SetInteractable(currentAffordances.physicalObject.velocityVectorIsInteractive);
        ballVelocityVector.GetComponent<DraggableVector>().Redraw();
        
        ball.GetComponent<Rigidbody>().isKinematic = false;
        ball.GetComponent<Rigidbody>().velocity = ballVelocity.Value;

        // Path Renderer config:
        showBallPath.Value = currentAffordances.physicalObject.showTrace;
        showBallPathToggle.gameObject.SetActive(currentAffordances.physicalObject.showTraceIsInteractive);
        showBallPathToggle.GetComponent<ToggleStartActivation>().SetToggleVisibility(currentAffordances.physicalObject.showTrace);

        // Gravity Force
        if (currentAffordances.gravityForce.isActive)
        {
            gravityIsInteractive.GetComponent<ToggleEvents>().eventLastRaised = 1;
            gravityIsInteractive.GetComponent<Toggle>().isOn = true;
            gravityIsOn.Raise();
        }
        else
        {
            gravityIsInteractive.GetComponent<ToggleEvents>().eventLastRaised = 0;
            gravityIsInteractive.GetComponent<Toggle>().isOn = false;
            gravityIsOff.Raise();
        }
        gravityIsActive.Value = currentAffordances.gravityForce.isActive;
        gravityIsInteractive.gameObject.SetActive(currentAffordances.gravityForce.isInteractive);
        showGravityField.Value = currentAffordances.gravityForce.showVector;











        // velocityLabel.SetActive(currentAffordances.physicalObject.showVelocityLabel);
        // showVelocityEquation.Value = currentAffordances.physicalObject.showVelocityEquation;
        // ballIsInteractive.Value = currentAffordances.physicalObject.isInteractive;
        // // Thrust Config:
        // thrustIsActive.Value = currentAffordances.centralForce.isActive;
        // thrustShowVector.Value = currentAffordances.centralForce.showVector;

        // centralForce.Value = Vector3.up * currentAffordances.centralForce.initialAngularVelocity;
        // centralForce.Value = Quaternion.Euler(currentAffordances.physicalObject.initialRotation.ToVector3()) * centralForce.Value;

        // thrustShowEquation.Value = currentAffordances.centralForce.showEquation;
        // thrustShowLabel.SetActive(currentAffordances.centralForce.showLabel);
        // thrustIsInteractive.Value = currentAffordances.centralForce.isInteractive;
        // // Extra:
        // referenceFrame.SetActive(currentAffordances.showReferenceFrame);

        // // Camera:
        // Vector3 cameraPos = currentAffordances.camera.position.ToVector3();
        // Slider zoomSlider = cameraZoomSlider.GetComponent<Slider>();
        // CameraManager cameraManager = mainCamera.GetComponent<CameraManager>();
        // float cameraZ = Mathf.Clamp(cameraPos.z, cameraManager.minZ, cameraManager.maxZ);
        // zoomSlider.minValue = cameraManager.GetSliderMinZ();
        // zoomSlider.maxValue = cameraManager.GetSliderMaxZ();
        // zoomSlider.SetValueWithoutNotify(cameraManager.CameraToSliderZ(cameraZ));
        // mainCamera.InitCamera(
        //     new Vector3(cameraPos.x, cameraPos.y, cameraZ),
        //     currentAffordances.camera.isLockedOnObject
        // );
        // cameraControls.gameObject.SetActive(currentAffordances.camera.showCameraControl);
    }
}
