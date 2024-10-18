using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject bee;
    bool beeSpawn = false;

    private void Update()
    {
        BeeSpawn();
    }

    void BeeSpawn()
    {
        if(beeSpawn == false)
        {
            Instantiate(bee, transform.position, transform.rotation);
            StartCoroutine(BeeSpawnTimer());
        }
    }

    IEnumerator BeeSpawnTimer()
    {
        beeSpawn = true;
        yield return new WaitForSeconds(2f);
        beeSpawn = false;
    }
}
