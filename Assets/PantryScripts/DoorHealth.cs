using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoorHealth : MonoBehaviour {

    public int health;
    public int maxHealth;

    //Door Health set on Start
    private void Start()
    {
        health = maxHealth;
    }

}
