using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLookAt : MonoBehaviour
{
    public Transform target;

    private Camera cameraTo;

    private float offsetX = 0;
    private float offsetY = 0;
    private float offsetZ = 0;

    private void Start()
    {
        cameraTo = Camera.main;
    }

    private void Update()
    {
        if (!GameManager.Instance.BonusGameStart)
            return;

        Vector3 screenPos = cameraTo.WorldToScreenPoint(new Vector3(target.position.x + offsetX, target.position.y + offsetY, target.position.z + offsetZ));

        transform.position = new Vector3(screenPos.x, screenPos.y, transform.position.z);
    }
}
