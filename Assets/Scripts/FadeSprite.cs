using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeSprite : MonoBehaviour
{
    public float fadeTime;
    public float targetAlpha;

    private Color color;
    private SpriteRenderer sprite;
    private float alpha;
    private bool faded;

    // Start is called before the first frame update
    void Start()
    {
        faded = false;
        // hardcoded for now
        SetFadeParams(3f, 1f);
        sprite = GetComponent<SpriteRenderer>();
        StartCoroutine(FadeTo(targetAlpha, fadeTime));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // https://answers.unity.com/questions/654836/unity2d-sprite-fade-in-and-out.html?childToView=654842#
    IEnumerator FadeTo(float aValue, float aTime)
    {
        alpha = sprite.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            color = sprite.color;
            sprite.color = new Color(color.r, color.g, color.b, Mathf.Lerp(alpha, aValue, t));
            yield return null;
        }
        faded = true;
    }

    void SetFadeParams(float fade_time, float target_alpha)
    {
        fadeTime = fade_time;
        targetAlpha = target_alpha;
    }

    public bool HasFaded()
    {
        return faded;
    }
}
