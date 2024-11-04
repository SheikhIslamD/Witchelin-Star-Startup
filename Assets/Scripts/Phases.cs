using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Phases : MonoBehaviour
{
    public float breakfastTime;
    public float lunchTime;
    public float dinnerTime;

    public static Phases instance;
    // Need to spawn a customer and have them place an order
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        StartCoroutine(Breakfast(breakfastTime));
    }

    IEnumerator Breakfast(float breakfastTime)
    {
        yield return new WaitForSeconds(breakfastTime);
        StartCoroutine(Lunch(lunchTime));
    }

    IEnumerator Lunch(float lunchTime)
    {
        yield return new WaitForSeconds(lunchTime);
        StartCoroutine(Dinner(dinnerTime));
    }

    IEnumerator Dinner(float dinnerTime)
    {
        yield return new WaitForSeconds(dinnerTime);
    }

    public void FinishGame(string result)
    {
        switch(result)
        {
            case "win":
                break;
            case "lose":
                break;
        }
    }
}
