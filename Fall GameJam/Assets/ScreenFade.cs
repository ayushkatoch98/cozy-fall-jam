using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFade : MonoBehaviour
{
    [SerializeField] private RawImage fadeImage;
    [SerializeField] private GameObject player;

    [HideInInspector] public bool isRespawing;
    private bool isFading = false;

    private void Start()
    {
        fadeImage.gameObject.SetActive(true);
        fadeImage.color = new Color(0.1f, 0.1f, 0.1f, 1);
        StartCoroutine(FadeToAlpha(0, 2.5f));
    }

    public void FadeIn()
    {
        if (!isFading)
        {
            StartCoroutine(FadeToAlpha(1, 1));
        }
    }

    public void FadeOut()
    {
        if (!isFading)
        {
            StartCoroutine(FadeToAlpha(0, 1));
        }
    }

    public void RespawnTransition()
    {
        StartCoroutine(Respawn(1f, 2f));
    }

    public IEnumerator Respawn(float duration, float waitTime)
    {
        isRespawing = true;
        StartCoroutine(FadeToAlpha(1, duration));
        yield return new WaitForSeconds(waitTime);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.transform.position = player.GetComponent<PlayerRespawn>().respawnLocation.position;
        StartCoroutine(FadeToAlpha(0, duration));
        isRespawing = false;
    }

    private IEnumerator FadeToAlpha(float targetAlpha, float fadeDuration)
    {
        isFading = true;

        Color currentColor = fadeImage.color;
        float startAlpha = currentColor.a;
        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, timer / fadeDuration);
            fadeImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            yield return null;
        }

        fadeImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, targetAlpha);
        isFading = false;
    }
}
