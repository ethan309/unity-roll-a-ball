using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autorotator : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Rotate
        Vector3 incrementalRotation = new Vector3(15, 45, 30);
        transform.Rotate(incrementalRotation * Time.deltaTime);
    }
}
