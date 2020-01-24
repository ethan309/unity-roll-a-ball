using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPins : MonoBehaviour
{
    public bool shouldReset;

    // Start is called before the first frame update
    void Start()
    {
        shouldReset = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            shouldReset = true;
        }
    }
}
