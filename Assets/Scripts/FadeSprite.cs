using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeSprite : MonoBehaviour
{
    public float fadeTime;
    public float targetAlpha;

    private Color color;
    private SpriteRenderer sprite;
    private Image image;
    private float alpha;
    private bool faded;

    // Start is called before the first frame update
    void Start()
    {
        faded = false;
        // hardcoded for now
        SetFadeParams(3f, 1f);
        sprite = GetComponent<SpriteRenderer>();
        // set to Spriterenderer's color if the component loaded
        if (sprite != null)
        {
            color = sprite.color;

        }
        // if no SpriteRenderer, use Image's color instead (for UI images)
        else
        {
            image = GetComponent<Image>();
            color = image.color;
        }
        StartCoroutine(FadeTo(targetAlpha, fadeTime));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // https://answers.unity.com/questions/654836/unity2d-sprite-fade-in-and-out.html?childToView=654842#
    IEnumerator FadeTo(float aValue, float aTime)
    {
        alpha = color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            // adjust the alpha towards its target value
            color = new Color(color.r, color.g, color.b, Mathf.Lerp(alpha, aValue, t));

            // set the appropriate color, depending on what component exists
            if (sprite != null)
                sprite.color = color;
            if (image != null)
                image.color = color;

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
