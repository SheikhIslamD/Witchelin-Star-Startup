using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Phases : MonoBehaviour
{
    public float breakfastTime;
    public float lunchTime;
    public float dinnerTime;

    public GameObject winScreen;
    public GameObject loseScreen;

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
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
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
                winScreen.SetActive(true);
                break;
            case "lose":
                loseScreen.SetActive(true);
                break;
        }
    }
}
