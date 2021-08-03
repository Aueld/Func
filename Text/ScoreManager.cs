using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject obj;

    private StreamWriter sw;
    private StringReader sr;
    private Text text;

    private string fullpth = @"Assets/Resources/Score";
    private string peth = "Score";

    private void Start()
    {
        text = GameObject.FindGameObjectWithTag("HighScore").GetComponent<Text>();
    }

    public void GameOver(/*string name, */int stage)
    {
        TextAsset txt = Resources.Load<TextAsset>(peth + stage.ToString());
        sr = new StringReader(txt.text);
        sw = new StreamWriter(fullpth + stage + ".txt");
        //sr.Read();
        //Debug.Log("저장되는 이름 " + name + " 저장되는 스테이지 " + stage + " 저장되는 점수 " + GameManager.Instance.totalScore);

        if (!File.Exists(fullpth + stage))
        {
            string str;
            //string[] word;

            if ((str = sr.ReadLine()) == null)
            {
                sw.WriteLine("0");
                PlayerPrefs.SetInt("Score1", 0);
                PlayerPrefs.SetInt("Score2", 0);
                PlayerPrefs.SetInt("Score3", 0);

                sw = new StreamWriter(fullpth + stage + ".txt");
                sr = new StringReader(txt.text);

                if ((str = sr.ReadLine()) != null)
                {

                    Debug.Log(str);
                    //word = str.Split(':');


                    if (int.Parse(str) < GameManager.Instance.BonusTotalScore)
                    {
                        //PlayerPrefs.SetInt("Score" + GameManager.Instance.stage, GameManager.Instance.totalScore);
                        
                        sw.WriteLine(GameManager.Instance.BonusTotalScore);

                        StartCoroutine(Finish());

                        //iTween.ValueTo(text.gameObject, iTween.Hash("from", 0, "to", GameManager.Instance.totalScore, "onUpdate", "Counter", "delay", 2, "time", 2));

                        text.text = "NEW High Score!!\n" + GameManager.Instance.BonusTotalScore;
                    }
                }
            }
            else
            {
                //Debug.Log(str);
                //word = str.Split(':');
                //if(int.Parse(str) == 0)
                //{
                //    PlayerPrefs.SetInt("Score" + GameManager.Instance.stage, 0);
                //}

                if (int.Parse(str) < GameManager.Instance.BonusTotalScore)
                {
                    sw.WriteLine(GameManager.Instance.BonusTotalScore);

                    StartCoroutine(Finish());

                    //PlayerPrefs.SetInt("Score" + GameManager.Instance.stage, GameManager.Instance.totalScore);
                    text.text = "NEW High Score!!\n" + GameManager.Instance.BonusTotalScore;
                    StartCoroutine(Shake());

                }
                else
                {
                    sw.WriteLine(str);
                    StartCoroutine(Finish());

                    PlayerPrefs.SetInt("Score" + GameManager.Instance.BonusStage, GameManager.Instance.BonusTotalScore);

                    text.text = "High Score\n" + str + "\nNOW Score\n" + GameManager.Instance.BonusTotalScore;
                    StartCoroutine(Shake());

                }
            }
        }
        GameManager.Instance.BonusStar = true;


        sw.Close();
        sr.Close();

        //File.Exists(fullpth + stage).Close();

        //FileStream fs;
    }

    private IEnumerator Finish()
    {
        yield return new WaitForSeconds(0.002f);
        if (obj != null)
            iTween.MoveAdd(obj, iTween.Hash("y", -1800f, "easeType", "easeOutBounce", "", "", "delay", 2));
        else
            Debug.Log("OBJ not found");
    }

    private IEnumerator Shake()
    {
        yield return new WaitForSeconds(0.002f);
        if (obj != null)
            iTween.ShakeRotation(obj, iTween.Hash("z", 2.0f, "delay", 2.0f, "time", 0.6f));
        else
            Debug.Log("OBJ not found");
    }
}
