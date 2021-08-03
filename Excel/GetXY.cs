using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetXY : MonoBehaviour
{
    public GameObject obj;
    // Update is called once per frame
    private void Update()
    {
        if (!GameManager.Instance.BonusGameStart)
            return;

        transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + 8, obj.transform.position.z);
    }
}
