using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace Iwaken
{
    [RequireComponent(typeof(ARRaycastManager))]
    public class CreateObject : MonoBehaviour
    {
        [SerializeField] GameObject objectPrefab;
        private ARRaycastManager raycastManager;
        List<ARRaycastHit> hitResults = new List<ARRaycastHit>();

        void Awake()
        {
            raycastManager = GetComponent<ARRaycastManager>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown((0)))
            {
                if (raycastManager.Raycast(Input.GetTouch(0).position, hitResults))
                {
                    Instantiate(objectPrefab, hitResults[0].pose.position, Quaternion.identity);
                }
            }
        }
    }
}