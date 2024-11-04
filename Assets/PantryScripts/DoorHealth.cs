using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DoorHealth : MonoBehaviour {

    public int health;
    public int maxHealth;

    public Slider hpSlider;

    //Door Health set on Start
    private void Start()
    {
        health = maxHealth;
        hpSlider.maxValue = maxHealth;
        hpSlider.value = maxHealth;
    }

    public void hpUpdate()
    {
        hpSlider.value = health;
        if (health <= 0)
        {
            Phases.instance.FinishGame("lose");
        }
    }

}
