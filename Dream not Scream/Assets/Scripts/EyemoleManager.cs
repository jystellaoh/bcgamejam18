// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

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
        public GameObject mole;

        public float spawnRadius;

        public GameObject camera;

        private float timeSinceLastSpawn = 0f;
        private float timeBetweenSpawns = 5f;
        
        private void Awake()
        {

        }

        private void Update() {

            if (Time.time - timeSinceLastSpawn >= timeBetweenSpawns) {
                SpawnEyemole();
                timeSinceLastSpawn = Time.time;
            }

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
