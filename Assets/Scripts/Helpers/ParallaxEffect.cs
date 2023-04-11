using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private GameObject[] layers;
    [SerializeField] private float[] parallaxScales;
    [SerializeField] private float smoothing = 1f;

    private Transform _cameraTransform;
    private Vector3 _previousCameraPosition;

    private void Start()
    {
        _cameraTransform = Camera.main.transform;
        _previousCameraPosition = _cameraTransform.position;
    }

    private void LateUpdate()
    {
        if (layers.Length != parallaxScales.Length) return;

        for (int i = 0; i < layers.Length; i++)
        {
            var parallaxAmount = (_previousCameraPosition.x - _cameraTransform.position.x) * parallaxScales[i];
            var backgroundTargetPositionX = layers[i].transform.position.x + parallaxAmount;
            var backgroundTargetPos = new Vector3(backgroundTargetPositionX, layers[i].transform.position.y,
                layers[i].transform.position.z);
            layers[i].transform.position = Vector3.Lerp(layers[i].transform.position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        _previousCameraPosition = _cameraTransform.position;
    }
}
