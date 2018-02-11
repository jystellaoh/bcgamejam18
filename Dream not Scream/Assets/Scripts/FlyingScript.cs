
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.XR.WSA.Input;
using UnityEngine.XR;
using HoloToolkit.Unity.InputModule.Examples.Grabbables;

public class FlyingScript : MonoBehaviour {

    public float speed = 10f;
    private bool isFlying = false;
    private Rigidbody rb;
    private Transform newTransform;

    private XRNode flyingHand;
    private InteractionSourceHandedness handedness = InteractionSourceHandedness.Left;

    private InteractionSourcePressType pressType = InteractionSourcePressType.Select;

    // Use this for initialization
    void Start()
    {
        InteractionManager.InteractionSourcePressed += InteractionSourcePressed;
        InteractionManager.InteractionSourceReleased += InteractionSourceReleased;
        newTransform = new GameObject().transform;
    }

    void Update()
    {
        Vector3 dir = InputTracking.GetLocalPosition(XRNode.LeftHand);
        Quaternion rotate = InputTracking.GetLocalRotation(XRNode.LeftHand);

        newTransform.position = dir;
         newTransform.rotation = rotate;

        if (isFlying)
        {
            this.transform.position += (newTransform.forward * speed * Time.deltaTime);

        }
    }
    // Update is called once per frame
    private void InteractionSourcePressed(InteractionSourcePressedEventArgs obj)
    {
        // g.Log(obj.pressType);
        if (obj.pressType == pressType && obj.state.source.handedness == handedness)
        {
            isFlying = true;     
        }
    }

    private void InteractionSourceReleased(InteractionSourceReleasedEventArgs obj)
    {
        // g.Log(obj.pressType);
        if (obj.pressType == pressType && obj.state.source.handedness == handedness)
        {
            isFlying = false;
        }
    }
}
