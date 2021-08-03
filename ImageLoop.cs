using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageLoop : MonoBehaviour
{
    private static WaitForEndOfFrame wait = new WaitForEndOfFrame();

    private float speed = 0.04f;
    private float ofs;

    private void Start()
    {
        StartCoroutine(loop());
    }

    private IEnumerator loop()
    {
        while (true)
        {
            //Plane�� �̹������� ����Ʈ�� �־�� �۵�

            ofs = speed * Time.time;
            
            transform.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(-ofs, 0);

            yield return wait;
        }
    }
}
