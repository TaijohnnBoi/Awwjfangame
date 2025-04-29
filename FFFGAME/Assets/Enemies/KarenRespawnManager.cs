using System.Collections;
using UnityEngine;

public class KarenRespawnManager : MonoBehaviour
{
    public KarenAI karenAI;

    public float minSpawnTime = 20f;
    public float maxSpawnTime = 40f;

    private void Start()
    {
        StartCoroutine(SpawnKarenLoop());
    }

    IEnumerator SpawnKarenLoop()
    {
        while (true)
        {
            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);

            if (!karenAI.gameObject.activeSelf)
            {
                karenAI.ShowKaren();
            }
        }
    }
}
