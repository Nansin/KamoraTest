using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;
    [SerializeField] private Vector3 offset;

    private Transform target;
    private Vector3 camTarget;
    private float camPosY;
    private Vector3 velocity = Vector3.zero;
    private float smoothTime = 0.15f;

    private void Awake()
    {
        Instance = this;
        camPosY = transform.position.y;
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    private void FixedUpdate()
    {
        if (target != null && target.hasChanged)
        {
            camTarget = target.position + offset;
            camTarget.y = camPosY;
        }
        transform.position = Vector3.SmoothDamp(transform.position, camTarget, ref velocity, smoothTime);
    }
}
