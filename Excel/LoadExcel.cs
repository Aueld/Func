using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LoadExcel : MonoBehaviour
{
    private List<Dictionary<string, object>> data_Stage;

    protected List<Vector3> objPos;
    protected List<int> list;

    protected int stage;

    private void Awake()
    {
        data_Stage = CSVReader.Read("StageTable");
        list = new List<int>();
        objPos = new List<Vector3>();

    }

    private void OnEnable()
    {
        // <column, row>

        for (int i = 0; i < data_Stage.Count; i++)
        {
            //STAGE의 열을 비교
            if (data_Stage[i]["STAGE"].ToString().Equals(GameManager.Instance.BonusStage.ToString()) && data_Stage[i]["STAGE"].ToString().Equals("10"))
            {
                list.Add(int.Parse(data_Stage[i]["ID"].ToString()));
                objPos.Add(new Vector3(float.Parse(data_Stage[i]["X"].ToString()), float.Parse(data_Stage[i]["Y"].ToString()), float.Parse(data_Stage[i]["Z"].ToString())));
            }
        }

        foreach (int i in list)
        {
            Debug.Log(i);
        }
        foreach(Vector3 v in objPos)
        {
            Debug.Log(v);
        }
    }

    protected List<Vector3> GetXYZ(string id)
    {
        if (data_Stage == null)
            data_Stage = CSVReader.Read("StageTable");
        
        List<Vector3> vList = new List<Vector3>();

        for (int i = 0; i < data_Stage.Count; i++)
        {
            try
            {
                stage = GameManager.Instance.BonusStage;
            }
            catch (NullReferenceException)
            {
                stage = 1;
            }

            if (data_Stage[i]["STAGE"].ToString().Equals(stage.ToString()) && data_Stage[i]["ID"].ToString().Equals(id))
            {
                vList.Add(new Vector3(float.Parse(data_Stage[i]["X"].ToString()), float.Parse(data_Stage[i]["Y"].ToString()), float.Parse(data_Stage[i]["Z"].ToString())));
            }
        }
        return vList;
    }
}
