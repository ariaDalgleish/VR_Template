using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateTeleportationRay : MonoBehaviour
{
    public GameObject leftTeleportation;
    public GameObject rightTeleportation;

    public InputActionProperty leftActivate;
    public InputActionProperty rightActivate;

    public InputActionProperty leftCancel;
    public InputActionProperty rightCancel;

    // Update is called once per frame
    void Update()
    { // make sure grid vaule is  zero and trigger vaule  is above a certain threshold to enable the teleportation
        leftTeleportation.SetActive(leftActivate.action.ReadValue<float>() == 0 && leftActivate.action.ReadValue<float>() > 0.1f); 
        rightTeleportation.SetActive(rightActivate.action.ReadValue<float>() == 0 && rightActivate.action.ReadValue<float>() > 0.1f);
    }
}
