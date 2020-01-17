using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public AudioSource itemSource;

    //Use this for initialization
    private void Start() {
        itemSource = GetComponent<AudioSource>();
    }

    //Update is called once per frame
    void Update ()  {

    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Target Object") {

            itemSource.Play ();

            Destroy(collision.gameObject);
        }
    }
}
