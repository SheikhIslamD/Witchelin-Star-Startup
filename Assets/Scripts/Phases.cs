using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Phases : MonoBehaviour
{
    public float breakfastTime;
    public float lunchTime;
    public float dinnerTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
        FinishGame();
    }

    public void FinishGame()
    {

    }
}
