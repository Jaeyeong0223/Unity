using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopDestroy : MonoBehaviour
{
    //public GameObject particle;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        //StartCoroutine(Particle());
    }

    /*IEnumerator Particle()
    {
        
        Instantiate(particle, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
    }*/
}
