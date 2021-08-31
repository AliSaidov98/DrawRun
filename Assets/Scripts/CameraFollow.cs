using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player = null;

    [SerializeField]
    private float smoothSpeed = 0.1f;

    private Vector3 offset = Vector3.zero;

    private Vector3 newPosition;

    private void Awake()
    {
        offset = transform.position - player.position;
    }

    private void FixedUpdate()
    {
        newPosition = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, newPosition, smoothSpeed);
    }
}
