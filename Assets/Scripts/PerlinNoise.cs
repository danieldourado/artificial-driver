using UnityEngine;

public class PerlinNoise
{
    float timeIncreasePerFrame = .01f;
    float randomFactor = 0.05f;
    float time = 0f;

    public PerlinNoise()
    {
        this.timeIncreasePerFrame =+ UnityEngine.Random.Range(-randomFactor, randomFactor);
        time = UnityEngine.Random.Range(0f, randomFactor*100);
    }

    public float GetValueBetweenMinusOneAndOne()
    {
        this.time += timeIncreasePerFrame;
        return GetNoise(this.time);
    }

    float GetNoise(float time)
    {
        return 2f * Mathf.PerlinNoise(time, 0.0f) - 1f;
    }

}