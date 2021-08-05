using System.Collections;
using System.Collections.Generic;
using Unity;
using UnityEngine;
using System;

public class BlockSpawn : LoadExcelTable
{
    public static readonly WaitForEndOfFrame wait_Seconds = new WaitForEndOfFrame();

    public GameObject block;

    private List<int> timerList = new List<int>();

    private void OnEnable()
    {
        vList = new List<Vector3>();
        timer = 0;
        index = 0;
        vList = GetXYZ((2001).ToString());
        timerList = GetTime(2001);

        StartCoroutine(Updater());
    }

    private void SpawnObject(GameObject obj)
    {
        if (vList[index + 1] != null)
            Instantiate(obj, vList[index], Quaternion.identity).transform.parent = transform;
    }

    private IEnumerator Updater()
    {
        while (true)
        {
            if (MainManager.Instance.stageChange)
                yield return wait_Seconds;
            else
            {
                //Debug.Log( "�� Ÿ�̸� : " + timer);
                timer++;// int.Parse(Time.deltaTime.ToString());
                try
                {
                    if (timer == timerList[index])
                    {
                        SpawnObject(block);
                        index++;
                    }
                }
                catch { }

                if (MainManager.Instance.gameStop)
                    yield return new WaitForSeconds(0.01f);
                else
                    yield return wait_Seconds;
            }
        }
    }
}
