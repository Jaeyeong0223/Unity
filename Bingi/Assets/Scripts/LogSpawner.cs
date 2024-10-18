using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogSpawner : MonoBehaviour
{
    public GameObject log;
    bool logSpawn = false;
    float delayTime;

    private void Start()
    {
        if(log.tag == "Log3")
        {
            delayTime = 8f;
        }
        else if(log.tag == "Log1" || log.tag == "Log2")
        {
            delayTime = 5f;
        }
    }

    private void Update()
    {
        LogSpawn();
    }

    void LogSpawn()
    {
        if (logSpawn == false)
        {
            Instantiate(log, transform.position, transform.rotation);
            StartCoroutine(BeeSpawnTimer());
        }
    }

    IEnumerator BeeSpawnTimer()
    {
        logSpawn = true;
        yield return new WaitForSeconds(delayTime);
        logSpawn = false;
    }
}
