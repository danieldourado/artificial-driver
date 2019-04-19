using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gene
{
    private float m_MinClamp = -1f;
    private float m_MaxClamp = 1f;

    public float randomFactor = 1f;

    public float h;
    public float v;
    public float handbrake;

    public Gene()
    {
        SetRandomFrameMoveInfo();
    }

    public void SetRandomFrameMoveInfo()
    {
        h = UnityEngine.Random.Range(-randomFactor, randomFactor);
        v = UnityEngine.Random.Range(-randomFactor, randomFactor);
        handbrake = UnityEngine.Random.Range(-randomFactor, randomFactor);
    }

    public void ClampValues()
    {
        h = Mathf.Clamp(h, m_MinClamp, m_MaxClamp);
        v = Mathf.Clamp(v, m_MinClamp, m_MaxClamp);
        handbrake = Mathf.Clamp(this.handbrake, m_MinClamp, m_MaxClamp);
    }
}