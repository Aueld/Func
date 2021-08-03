using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ItemSpawn : LoadExcelTable
{
    public static readonly WaitForEndOfFrame wait_Seconds = new WaitForEndOfFrame();
    public GameObject book;

    private void OnEnable()
    {
        vList = new List<Vector3>();
        timer = 0;
        index = 0;
        vList = GetXYZ((1001).ToString());

        StartCoroutine(Updater());
        //SpawnObject(book);
    }

    private void SpawnObject(GameObject obj)
    {
        if(vList[index+1] != null)
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
                if (!MainManager.Instance.playerHit)
                {


                    timer++;// int.Parse(Time.deltaTime.ToString());
                    try
                    {
                        if (timer == GetTime()[index])
                        {
                            SpawnObject(book);
                            index++;
                        }
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
}
