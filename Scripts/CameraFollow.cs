using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Camera cam;
    public float baseOrthographicSize = 5f;
    public float runOrthographicSize = 7f;

    public Transform target;

    [Header("Configuración de Posición")]
    public Vector3 baseOffset;
    public float smoothSpeed = 0.125f;

    [Header("Configuración de Sprint (Shift)")]
    public Vector3 runOffsetAdjustment = new Vector3(0, 0, -2f);
    public float offsetSmoothSpeed = 5f;

    private Vector3 currentOffset;

    void Start()
    {
        cam = GetComponent<Camera>();
        if (cam.orthographic)
        {
            cam.orthographicSize = baseOrthographicSize;
        }
        currentOffset = baseOffset;
    }

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("El objetivo de la cámara no está asignado.");
            return;
        }

        HandleRunInput();

        Vector3 desiredPosition = target.position + currentOffset;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }

    void HandleRunInput()
    {
        if (cam == null || !cam.orthographic) return;

        float targetSize;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            targetSize = runOrthographicSize;
        }
        else
        {
            targetSize = baseOrthographicSize;
        }

        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetSize, Time.deltaTime * offsetSmoothSpeed);
    }
}
