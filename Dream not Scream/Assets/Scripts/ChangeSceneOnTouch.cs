// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HoloToolkit.Unity.InputModule.Examples.Grabbables
{
    /// <summary>
    /// Simple class to change the color of grabbable objects based on state
    /// </summary>
    public class ChangeSceneOnTouch : MonoBehaviour
    {

        [SerializeField]
        private BaseGrabbable grabbable;

        public int sceneToChangeTo = 0;
        
        private void Awake()
        {
            if (grabbable == null)
            {
                grabbable = GetComponent<BaseGrabbable>();
            }
          
            grabbable.OnContactStateChange += ChangeScene;
            grabbable.OnGrabStateChange += ChangeScene;
        }

        private void ChangeScene(BaseGrabbable baseGrab)
        {

            Debug.Log(baseGrab.ContactState);

            switch (baseGrab.ContactState)
            {
                case GrabStateEnum.Inactive:
                    break;

                case GrabStateEnum.Multi:
                    SceneManager.LoadScene(sceneToChangeTo);
                    break;

                case GrabStateEnum.Single:
                    SceneManager.LoadScene(sceneToChangeTo);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            switch (baseGrab.GrabState)
            {
                case GrabStateEnum.Inactive:
                    break;

                case GrabStateEnum.Multi:
                    SceneManager.LoadScene(sceneToChangeTo);
                    break;

                case GrabStateEnum.Single:
                    SceneManager.LoadScene(sceneToChangeTo);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }


        }
    }
}
