using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float health = 100;
    public float movementSpeed = 80;
    public float rotationSpeed = 200;
    public float horizontalInput;
    public float verticalInput;

    public int attackPower = 1;

    private Vector3 haltPlayer = new Vector3(0, 0, 0);
    private Rigidbody playerRb;
    private Animator playerAnimator;
    private float speedDeclineCheck = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    // This method is called in update to control player movement
    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = (Input.GetAxis("Vertical"));
        if(verticalInput > 0)
        {
            if (verticalInput >= speedDeclineCheck)
            {
                playerAnimator.SetFloat("speed_f", verticalInput);
                PlayerFullSpeed();
                transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * movementSpeed);
            } else
            {
                //verticalInput = 0;
                PlayerHalt();
                playerAnimator.SetFloat("speed_f", 0);
            }
        }
        transform.Rotate(Vector3.up * Time.deltaTime * horizontalInput * rotationSpeed);
        //if(verticalInput == 0)
        //{
        //    PlayerHalt();
        //    playerAnimator.SetFloat("speed_f", 0);
        //}
        speedDeclineCheck = verticalInput;
    }

    void PlayerFullSpeed()
    {
        GameManager.instance.SetTimeSlowMotion();
        playerAnimator.speed = 6;
        rotationSpeed = 400;
    }

    void PlayerHalt()
    {
        GameManager.instance.SetTimeNormal();
        playerAnimator.speed = 1;
        rotationSpeed = 200;
        //playerRb.angularVelocity = haltPlayer;
    }

    private void OnCollisionEnter(Collision collision)
    {
        PoliceBehaviour policeMan = collision.gameObject.GetComponent<PoliceBehaviour>();
        if(policeMan)
        {
            GameManager.instance.GetDamage(attackPower);
        }
    }

}