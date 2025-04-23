using System.Collections;
using UnityEngine;

public class DasterRespawnManager : MonoBehaviour
{
    public DasterAI dasterAI;

    public float minRespawnTime = 8f;
    public float maxRespawnTime = 15f;

    public void RespawnDasterLater()
    {
        StartCoroutine(RespawnCoroutine());
    }

    IEnumerator RespawnCoroutine()
    {
        float waitTime = Random.Range(minRespawnTime, maxRespawnTime);
        yield return new WaitForSeconds(waitTime);

        // Respawn Daster
        dasterAI.StartOrderCycle();
    }
}
