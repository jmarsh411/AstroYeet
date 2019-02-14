using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFade : MonoBehaviour
{
    public float fadeTime;
    public float targetAlpha;

    private Color color;
    private SpriteRenderer sprite;
    private float alpha;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        StartCoroutine(FadeTo(1f, 3f));  // hardcoded for now
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FadeTo(float aValue, float aTime)
    {
        alpha = sprite.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            color = sprite.color;
            sprite.color = new Color(color.r, color.g, color.b, Mathf.Lerp(alpha, aValue, t));
            yield return null;
        }
    }
}
