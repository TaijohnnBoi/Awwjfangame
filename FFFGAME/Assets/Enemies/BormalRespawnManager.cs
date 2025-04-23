using System.Collections;
using UnityEngine;

public class BormalRespawnManager : MonoBehaviour
{
    public BormalAI bormalAI;

    public float minRespawnTime = 8f;
    public float maxRespawnTime = 15f;

    public void RespawnBormalLater()
    {
        StartCoroutine(RespawnCoroutine());
    }

    IEnumerator RespawnCoroutine()
    {
        float waitTime = Random.Range(minRespawnTime, maxRespawnTime);
        yield return new WaitForSeconds(waitTime);

        // Respawn Bormal
        bormalAI.ShowOrder();
    }
}
