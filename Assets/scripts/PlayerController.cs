using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    //Public veriables show up in the inspector as a property of the script
    public float speed;
    public Text CountText, WinText;

    private Rigidbody rb;    
    private int count;
    
    //Called on the first frame 
    void Start()
    {
        //This gets the attached rigidBody component (if there is one)
        rb = GetComponent<Rigidbody>();
        count = 0;
        UpdateScore();
        WinText.text = "";
    }

    //Called before rendering a frame
    void Update()
    {

    }

    //Called before performing physics calculations
    void FixedUpdate()
    {        
        //Code to move ball will go here.
        float moveHoritzontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHoritzontal, 0, moveVertical);

        rb.AddForce(movement * speed);

        //Gives it a jump up
        //if (Input.GetKeyDown(KeyCode.Space))
        //    rb.AddForce(new Vector3(0, 100, 0));
    }

    void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject);
        if (other.gameObject.CompareTag("pickups"))
        {
            other.gameObject.SetActive(false);
            count++;
            if(count >= 12)
                WinText.text = "You Win";
            else
                UpdateScore();
        }            
    }

    void UpdateScore()
    {
        CountText.text = "Current Score: " + count.ToString();
    }
}
