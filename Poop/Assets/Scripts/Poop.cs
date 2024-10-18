using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : MonoBehaviour
{
    public GameObject poopPrefab;
    public float spawnDelay = 3f;
    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= spawnDelay)
        {
            SpawnPoop();    //¶Ë»ý¼º
            timer = 0f;
        }
    }

    void SpawnPoop()
    {
        float xPosition = Random.Range(-2.2f, 2.2f);
        Vector3 spawnPosition = new Vector3(xPosition, 5.24f, 0);
        Instantiate(poopPrefab, spawnPosition, transform.rotation);
    }
}
