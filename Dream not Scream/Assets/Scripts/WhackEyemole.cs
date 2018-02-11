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
    public class WhackEyemole : MonoBehaviour
    {

        [SerializeField]
        private BaseGrabbable grabbable;
        [SerializeField]
        public AudioSource deathSound;
        [SerializeField]
        private AudioSource phrase = null;

        private float minY = -5f; 
        private float baseY = 0.1f;

        private bool isDying = false;

        private float timeSinceLastPhrase = 0f;
        private float timeBetweenPhrases = 10f;
        
        private void Awake()
        {
            if (grabbable == null)
            {
                grabbable = GetComponent<BaseGrabbable>();
            }
          
            grabbable.OnContactStateChange += Whack;
        }

        public void SetPhrase(AudioSource phr) {
            this.phrase = phr;
        }

        private void Update() {

            Vector3 molePosition = gameObject.transform.position;

            if (isDying) {
                molePosition.y -= 0.1f;
                gameObject.transform.position = molePosition;
            } 
            else if (Time.time - timeSinceLastPhrase >= timeBetweenPhrases) {
                phrase.Play();
                timeSinceLastPhrase = Time.time;
            }

            if (gameObject.transform.position.y <= minY)
            {
                Destroy(gameObject);
            }

            if (gameObject.transform.position.y <= baseY) {
                molePosition += Vector3.up * 0.01f;
                gameObject.transform.position = molePosition;
            }


        }

        private void Whack(BaseGrabbable baseGrab)
        {

            Debug.Log(baseGrab.ContactState);

            switch (baseGrab.ContactState)
            {
                case GrabStateEnum.Inactive:
                    break;

                case GrabStateEnum.Multi:
                    isDying = true;
                    deathSound.Play();
                    break;

                case GrabStateEnum.Single:
                    isDying = true;
                    deathSound.Play();
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }


        }
    }
}
