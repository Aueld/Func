using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Faded : MonoBehaviour
{
    private Image image;

    private float fadeCount = 1f;

    private void OnEnable()
    {
        image = GameObject.FindGameObjectWithTag("img").GetComponent<Image>();
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        fadeCount = 1f;
        while (fadeCount > 0f)
        {
            fadeCount -= 0.02f;
            yield return new WaitForSeconds(0.01f);
            if (image != null)
                image.color = new Color(0, 0, 0, fadeCount);
            else
                Debug.Log("Image not found");
        }
    }
}