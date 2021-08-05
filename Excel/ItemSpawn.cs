using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ItemSpawn : LoadExcelTable
{
    private static readonly WaitForEndOfFrame wait_Seconds = new WaitForEndOfFrame();

    public GameObject itemInt;
    public GameObject itemCha;
    public GameObject itemSen;
    public GameObject itemHea;

    private List<Vector3>[] vvList = new List<Vector3>[4];
    private List<int>[] timerList = new List<int>[4];

    private int[] indexA = new int[4];

    private void OnEnable()
    {
        //vList = new List<Vector3>();
        //vList = GetXYZ((1001).ToString());

        timer = 0;
        


        for (int i = 0; i < 4; i++)
        {
            vvList[i] = GetXYZ((1001 + i).ToString());
            timerList[i] = GetTime(1001 + i);
            indexA[i] = 0;
        }

        StartCoroutine(Updater());
        //SpawnObject(book);
    }

    private void SpawnObject(GameObject obj, int i)
    {
        if(vvList[i][indexA[i]+1] != null)
            Instantiate(obj, vvList[i][indexA[i]], Quaternion.identity).transform.parent = transform;
    }

    private IEnumerator Updater()
    {
        while (true)
        {
            if (MainManager.Instance.stageChange)
                yield return wait_Seconds;
            else
            {
                if (!MainManager.Instance.playerHit)
                {


                    timer++;// int.Parse(Time.deltaTime.ToString());
                    try
                    {
                        TimeMatch(itemInt, 0);
                        TimeMatch(itemCha, 1);
                        TimeMatch(itemSen, 2);
                        TimeMatch(itemHea, 3);
                    }
                    catch { }
                }
                if (MainManager.Instance.gameStop)
                    yield return new WaitForSeconds(0.01f);
                else
                    yield return wait_Seconds;
            }
        }
    }

    private void TimeMatch(GameObject obj, int i)
    {
        if (timer == timerList[i][indexA[i]])
        {
            SpawnObject(obj, i);
            indexA[i]++;
        }
    }
}
