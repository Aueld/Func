using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraShake : MonoBehaviour
{
    public float ShakeAmount = 0.04f;

    private Vector3 initialPosition;
    private Vector3 endPosition;

    private Drag drag;

    private float div = 1f;
    private float ShakeTime;

    private void Start()
    {
        drag = GameObject.FindGameObjectWithTag("Player").GetComponent<Drag>();
        initialPosition = new Vector3(0f, 3f, -9f);
        endPosition = new Vector3(0f, 6f, 0f);
    }

    private void Update()
    {
        if (!GameManager.Instance.BonusGameStart)
            return;

        if (ShakeTime > 0 && drag.cameraMove)
        {
            transform.position = Random.insideUnitSphere * (ShakeAmount / div) + endPosition;
            ShakeTime -= Time.deltaTime;

            //ShakeAmount -= 1 / (ShakeTime * 100);
        }
        else
        {
            div = 1f;
            ShakeTime = 0.0f;
            if(!drag.cameraMove)
                transform.position = initialPosition;
            else
                transform.position = endPosition;
        }
    }

    public void ShakeForTime(float time)
    {
        ShakeTime = time;
    }

    public void SetDiv(float div)
    {
        this.div = div;
    }
}
