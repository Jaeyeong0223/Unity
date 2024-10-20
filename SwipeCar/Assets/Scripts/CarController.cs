using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    GameObject gameDirector;
    float swipeLength, speed = 0;
    Vector2 startPos, endPos;
    public Vector2 initPos;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        gameDirector = GameObject.Find("GameDirector");
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            endPos = Input.mousePosition;
            swipeLength = endPos.x - startPos.x;
            speed = swipeLength / 500f;

            if (gameDirector.GetComponent<GameDirector>().state == GameDirector.State.ready)
            {
                GetComponent<AudioSource>().Play();
                gameDirector.GetComponent<GameDirector>().state = GameDirector.State.run;
            }
        }

        if (gameDirector.GetComponent<GameDirector>().state == GameDirector.State.run)
        {
            transform.Translate(speed, 0, 0);
            speed *= 0.98f;
            if (speed < 0.001f)
                gameDirector.GetComponent<GameDirector>().state = GameDirector.State.stop;
        }
    }
}


