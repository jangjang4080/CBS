using UnityEngine;
using System.Collections;
using DG.Tweening;

public static class GlobalAction
{
    public static void ButtonPushScale(GameObject button, float duration = 0.4f)
    {
        button.transform.DOPunchScale(Vector3.one, duration).SetEase(Ease.InSine).Play();
    }

    public static void ButtonScaleTo(GameObject button, float duration = 0.3f)
    {
        button.transform.DOScale(Vector3.one * 1.3f, duration).SetEase(Ease.InSine).Play();
    }

    public static void AppearNotification(GameObject target, float duration = 0.2f
        , GameObject completeTarget = null, string OnCompleteDisappearAction = "")
    {
        target.transform.localScale = new Vector3(0.01f, 0.01f, 1.0f);

        target.transform.DOScale(Vector3.one, duration)
            .SetEase(Ease.InOutQuint).SetTarget(target)
            .OnComplete(() =>
            {
                if (completeTarget.activeSelf == true)
                {
                    if (completeTarget != null && string.IsNullOrEmpty(OnCompleteDisappearAction) == false)
                    {
                        completeTarget.SendMessage(OnCompleteDisappearAction);
                    }
                }
            })
            .Play();
    }

    public static void DisappearNotification(GameObject target, float duration = 0.25f, 
                                             GameObject completeTarget = null, string OnCompleteDisappearAction = "")
    {
        target.transform.DOScale(Vector3.one * 0.001f, duration)
            .SetEase(Ease.InOutQuint)
            .OnComplete(() =>
            {
                if (completeTarget != null && string.IsNullOrEmpty(OnCompleteDisappearAction) == false)
                    completeTarget.SendMessage(OnCompleteDisappearAction);
            })
            .Play();
    }
}