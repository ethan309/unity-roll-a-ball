using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ResetPins : MonoBehaviour
{
    private GameObject[] pins;

    // Start is called before the first frame update
    void Awake()
    {
        pins = GameObject.FindGameObjectsWithTag("Pin");
        print(pins);
        print(pins.Length);
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Triggerred");
        if (other.gameObject.CompareTag("Ball"))
        {
            foreach(GameObject pin in pins)
            {
                print(pin);
                pin.GetComponent<Resetable>().ToggleReset(true);
            }
        }
    }
}
