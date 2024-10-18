using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGscroll : MonoBehaviour
{
    private new Renderer renderer;

    public float speed;
    float offset;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        offset += Time.deltaTime * speed;
        renderer.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
