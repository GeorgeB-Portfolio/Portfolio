using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Stating all variables related to the player character and Timer.
public class Playercontroller : MonoBehaviour
{
    float MAXVELOCITY, MoveSpeed, Acceleration, JumpVelocity;
    Rigidbody body;
    public Camera MainCamera;
    public bool Grounded;
    public Text PlayerHealth;
    public int Health;
    public Text Points;
    public int Score;
    float Timer;
    public Text Timer1;
    
    // Start is called before the first frame update
    // Setting values/initial values to all of the varaibles in start so are used from
    // when the games is run
    void Start()
    {
        body = GetComponent<Rigidbody>();
        MAXVELOCITY = 8f;
        MoveSpeed = 2f;
        Acceleration = 10f;
        Grounded = false;
        JumpVelocity = 300f;
        Health = 10;
        PlayerHealth.text = "Health: " + Health ;
        Score = 0;
        Points.text = "Score: " + Score;
        Timer = 60f;

    }
    // Movement of character
    void Movement()
    {
        // Movement of player only left and right.
        float horizontal = Input.GetAxis("Horizontal");
        if (Input.GetButton("Horizontal") && (body.velocity.x < MAXVELOCITY && body.velocity.x > -MAXVELOCITY))
        {
            body.velocity += Vector3.right * horizontal * MoveSpeed * Acceleration * Time.deltaTime;

        }
        // Player jumping which is only possible when touching the ground (objects with
        // the grounded tag.
        if (Input.GetButton("Jump") && Grounded == true) 
        {
            Grounded = false;
            body.velocity += Vector3.up * JumpVelocity * Time.deltaTime;
        }

    }
    // Collision detection for both when touching the ground and enemies.
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            Grounded = true;
        }
        else if (collision.transform.tag == "Enemy")
        {
            Health = Health - 1;
            Score = Score + 1000;
            Points.text = "Score: " + Score;
            PlayerHealth.text = "Health: " + Health;
        }
    }

    // Update is called once per frame
    // Calling the movement function, changing the camera position and timer all updated
    // every frame.
    void Update()
    {
        Movement();
        Vector3 camPos = new Vector3(body.position.x, MainCamera.transform.position.y, MainCamera.transform.position.z);
        MainCamera.transform.position = camPos;
        if (Timer > 0.1f)
        {
            timer();
        }
        
    }
    // When touching the collectible (Coins) an event triggered making the coin dissapear
    // and adding 100 score to the total score.
    private void OnTriggerEnter(Collider collectible)
    {
        if(collectible.transform.tag == "Collectible")
        {
            Score = Score + 100;
            Points.text = "Score: " + Score;
            Destroy(collectible.transform.gameObject);
        }

    }
    // Function that is called every frame earlier that counts down.
    private void timer()
    {
        Timer = Timer - Time.deltaTime;
        Timer1.text = "Timer: " + Timer;
    }
       
       
        

 
}
