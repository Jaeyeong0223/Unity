using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public enum State { ready, run, stop };
    public State state;
    GameObject car, flag;
    public Text distance, txtScore;
    int score = 1000;

    // Start is called before the first frame update
    void Start()
    {
        state = State.ready;
        car = GameObject.Find("car");
        flag = GameObject.Find("flag");
    }

    // Update is called once per frame
    void Update()
    {
        float length = flag.transform.position.x - car.transform.position.x;
        distance.text = "목표지점까지 " + length.ToString("F2") + "m";
        switch (state)
        {
            case State.stop:
                score = 10000 - (1000 * (int)length);
                txtScore.text = "SCORE " + score.ToString();
                if (Input.GetMouseButtonDown(1))
                {
                    state = State.ready;
                    car.transform.position = car.GetComponent<CarController>().initPos;
                }
                break;
        }
    }
}