using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewScore : MonoBehaviour
{
    public Transform target;

    private Camera cameraTo;
    private Text text;

    private bool check = false;

    private float offsetX = 0;
    private float offsetY = 0;
    private float offsetZ = 0;
    private float fade;

    private void Start()
    {
        cameraTo = Camera.main;
        fade = 0f;
        text = GetComponent<Text>();
    }

    private void Update()
    {
        if (!GameManager.Instance.BonusGameStart && !check)
            return;

        Vector3 screenPos = cameraTo.WorldToScreenPoint(new Vector3(target.position.x + offsetX, target.position.y + offsetY, target.position.z + offsetZ));

        transform.position = new Vector3(screenPos.x, screenPos.y, transform.position.z);

        if (check)
        {
            check = false;
            StartCoroutine(FadeText());
        }
    }

    public void GetScore()
    {
        if (!GameManager.Instance.BonusGameStart)
            return;
        text.text = GameManager.Instance.BonusScore.ToString();
        check = true;
    }

    private IEnumerator FadeText()
    {
        fade = 1f;
        while (fade > 0f)
        {
            fade -= 0.02f;
            yield return new WaitForSeconds(0.005f);
            if (text != null)
                text.color = new Color(255, 255, 255, fade);
            else
                Debug.Log("Not Found Text");
        }
    }
}
