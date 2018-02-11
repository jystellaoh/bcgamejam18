// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using HoloToolkit.Unity;
namespace HoloToolkit.Unity.InputModule.Examples.Grabbables
{
    /// <summary>
    /// Simple class to change the color of grabbable objects based on state
    /// </summary>
    public class EyemoleManager : MonoBehaviour
    {

        [SerializeField]
        public AudioSource[] phrases;
        [SerializeField]
        public AudioSource winningAudio;
        [SerializeField]
        public GameObject mole;

        public float spawnRadius;

        public GameObject camera;

        private float timeSinceLastSpawn = 0f;
        private float timeBetweenSpawns = 10f;

        private bool isFading = false; 

        private void Update() {

            if (Time.time - timeSinceLastSpawn >= timeBetweenSpawns) {
                SpawnEyemole();
                timeSinceLastSpawn = Time.time;
            }
        }


        public void CheckIfDone() {
            WhackEyemole[] eyemoles = Object.FindObjectOfType(WhackEyemole);
            if (eyemoles.count == 0) {
                winningAudio.Play();
                FadeManager.DoFade(0f, 5f, null, null);
                Invoke("GoBackToMain", 5);
            }
        }

        private void GoBackToMain() {
            SceneManager.LoadScene(0);
        }

        private void SpawnEyemole() {

            GameObject eyemoleObj = Instantiate(mole);   
            System.Random rndX =  new System.Random();
            System.Random rndY = new System.Random();
            mole.transform.position = camera.transform.position + new Vector3(Mathf.Sin(rndX.Next(0, 360) * 2 * Mathf.PI / 180), 0, Mathf.Cos(rndY.Next(0, 360) * 2 * Mathf.PI / 180))*spawnRadius;
            System.Random rndP = new System.Random();
            AudioSource randomPhrase = phrases[(int) rndP.Next(0, phrases.Count())];
            mole.GetComponent<WhackEyemole>().SetPhrase(randomPhrase);
        }
    }
}
