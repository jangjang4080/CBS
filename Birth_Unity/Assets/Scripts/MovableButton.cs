using UnityEngine;
using System.Collections;
using DG.Tweening;

public class MovableButton : MonoBehaviour
{
    public enum Type
    {
        Rotation,
        Scale,
    }

    public bool autoStart;
    public Type type = Type.Scale;
    public float rotationDelayTime = 0.0f;
    public float rotationValue = 20.0f;

    private string m_TweenID = "button";

    public void RotationAction()
    {
        StopAction();

        InitRotation();
        PunchRotation();
    }

    public void StopAction()
    {
        DOTween.Kill(this.m_TweenID);
    }

    public void ScaleAction()
    {
        StopAction();

        ScaleToX();
    }

    public void InitRotation()
    {
        transform.localRotation = Quaternion.identity;
    }

    void PunchRotation()
    {
        Vector3 euler = this.gameObject.transform.localEulerAngles;

        Sequence seq = DOTween.Sequence();
        seq.SetDelay(2)
            .Append(DOTween.Punch(() => this.transform.localEulerAngles, (z) => this.gameObject.transform.localEulerAngles = z, new Vector3(euler.x, euler.y, this.rotationValue), 0.5f, 10)
        )
        .SetLoops(-1)
        .SetId(this.m_TweenID)
            .Play();
    }

    void ScaleToX()
    {
        Vector3 scale_1 = new Vector3(1.025f, 0.99f, 1);

        this.transform.DOScale(scale_1, 0.75f).OnComplete(this.ScaleToY).SetId(this.m_TweenID).Play();
    }

    void ScaleToY()
    {
        Vector3 scale_2 = new Vector3(0.975f, 1.01f, 1);

        this.transform.DOScale(scale_2, 0.75f).OnComplete(this.ScaleToX).SetId(this.m_TweenID).Play();
    }

    void Start()
    {
        if (rotationDelayTime == 0.0f)
            rotationDelayTime = Random.Range(1.0f, 10.0f);

        if (autoStart)
        {
            if (type == Type.Rotation)
                RotationAction();
            else if (type == Type.Scale)
                ScaleAction();
        }
    }
}
