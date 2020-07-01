using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_movements : MonoBehaviour
{
    public float velocity = 10f;
    public Rigidbody rb;
    public int score;
    public Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        setScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical"); 

        Vector3 movement = new Vector3(moveX, 0.0f, moveZ);

        rb.AddForce(movement * velocity);

    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("PickUp")) {
            other.gameObject.SetActive(false);
            score += 1;
            setScoreText();
            print("Score: " + score);
            
        }
    }

    void setScoreText(){
        ScoreText.text = "Score: " + score.ToString();
    }
}

