using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    public float movementSpeed;

    private int score;
    public Text scoreDisplayText;

    public Text endgameMessage;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        UpdateScore(0);
        endgameMessage.text = "";
    }

    void UpdateScore(int newScore)
    {
        score = newScore;
        scoreDisplayText.text = "Score: " + score.ToString();
        if(score >= 500)
        {
            endgameMessage.text = "Game Over";
            movementSpeed = 0;
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        const float GROUND_LEVEL = 0.5F;
        float moveUp = (transform.position.y - GROUND_LEVEL < 0.1) ? Input.GetAxis("Jump") : 0;

        const int jumpHeight = 5;
        Vector3 forceApplied = new Vector3(moveHorizontal, moveUp * jumpHeight, moveVertical);
        rb.AddForce(forceApplied * movementSpeed);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Target Object"))
        {
            other.gameObject.SetActive(false);
            UpdateScore(score + 100);
        }
    }
}
