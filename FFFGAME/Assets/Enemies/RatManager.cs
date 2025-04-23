using System.Collections;
using UnityEngine;

public class RatManager : MonoBehaviour
{
    public GameObject ratButton;
    public Vector2 spawnPosition;
    public float respawnDelay = 10f;
    public GameObject screenCoverImage;

    public void StartRespawn()
    {
        StartCoroutine(Respawn());
    }


    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnDelay);

        if (screenCoverImage != null)
            screenCoverImage.SetActive(false); // 🧽 cleans up after rats

        RectTransform rt = ratButton.GetComponent<RectTransform>();
        rt.anchoredPosition = spawnPosition;
        ratButton.SetActive(true);
    }
}
