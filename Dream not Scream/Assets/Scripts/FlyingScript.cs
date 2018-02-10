
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.XR.WSA.Input;
using HoloToolkit.Unity.InputModule.Examples.Grabbables;

public class FlyingScript : MonoBehaviour {

    public float speed = 0.00001f;
    private bool isFlying = false;
    private Rigidbody rb;

    public GameObject camera;
    private GameObject leftController;

    private InteractionSourcePressType pressType = InteractionSourcePressType.Select;

    // Use this for initialization
    void Start()
    {
        InteractionManager.InteractionSourcePressed += InteractionSourcePressed;
        InteractionManager.InteractionSourceReleased += InteractionSourceReleased;
    }

    void Update()
    {
        this.leftController = GetComponentInChildren<Grabber>().gameObject;

        if (isFlying)
        {
            // Vector3 dir = leftController.transform.position - this.camera.transform.position;
            this.transform.position += (leftController.transform.forward * speed * Time.deltaTime);

        }
    }
    // Update is called once per frame
    private void InteractionSourcePressed(InteractionSourcePressedEventArgs obj)
    {
        // g.Log(obj.pressType);
        if (obj.pressType == pressType) // && obj.state.source.handedness == handedness)
        {
            isFlying = true;
        }
    }

    private void InteractionSourceReleased(InteractionSourceReleasedEventArgs obj)
    {
        // g.Log(obj.pressType);
        if (obj.pressType == pressType) // && obj.state.source.handedness == handedness)
        {
            isFlying = false;
        }
    }
}
