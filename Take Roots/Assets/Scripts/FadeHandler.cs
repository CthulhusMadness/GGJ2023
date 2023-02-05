using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FadeHandler : MonoBehaviour
{

    [SerializeField] private CanvasGroup fadeCanvasGroup;
    [SerializeField] private CanvasGroup dayCanvasGroup;
    [SerializeField] private TMP_Text dayText;
    [SerializeField] private float fadeDuration;
    [SerializeField] private float textFadeDuration;

    private void OnEnable()
    {
        SceneManager.Instance.OnStartDay += Fade;
    }

    private void OnDestroy()
    {
        SceneManager.Instance.OnStartDay -= Fade;
    }

    public void Fade(bool startDay)
    {
        dayCanvasGroup.alpha = 0;
        dayText.text = $"Day {GameManager.Instance.Day}";
        StartCoroutine(FadeDelay(startDay));
    }

    private IEnumerator FadeDelay(bool startDay)
    {
        var timer = 0f;
        if (startDay)
        {
            fadeCanvasGroup.alpha = 1;
            dayCanvasGroup.alpha = 0;
            while (timer < textFadeDuration)
            {
                dayCanvasGroup.alpha = timer / textFadeDuration;
                timer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            dayCanvasGroup.alpha = 1;
        }
        else
            fadeCanvasGroup.alpha = 0;

        timer = 0f;
        while (timer < fadeDuration)
        {
            var perc = timer / fadeDuration;
            fadeCanvasGroup.alpha = startDay ? 1 - perc : perc;
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
