using UnityEngine;
using TMPro; 
using System.Collections;

public class ScoreFeedback : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float duration = 1f;
    public float moveUpDistance = 50f;

    private CanvasGroup canvasGroup;
    private Vector3 initialScale;
    private Vector3 targetScale;
    private Vector3 startPos;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        initialScale = transform.localScale;
        targetScale = initialScale * 0.5f; // réduction à 50%
    }

    public void Init(string value, Color color)
    {
        text.text = value;
        text.color = color;
        startPos = transform.position;
        StartCoroutine(Animate());
    }

    private IEnumerator Animate()
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;

            // Fade out
            canvasGroup.alpha = 1f - t;

            // Shrink
            transform.localScale = Vector3.Lerp(initialScale, targetScale, t);

            // Move up
            transform.position = startPos + Vector3.up * moveUpDistance * t;

            elapsed += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}
