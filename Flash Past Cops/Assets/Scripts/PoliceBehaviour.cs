using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PoliceBehaviour : MonoBehaviour
{
    public float movementSpeed = 10;
    private Animator policeAnimator;
    public NavMeshAgent enemyAgent;
    public Transform playerTransform;
    private float offsetY = 0.2f;

    private void Awake()
    {
        playerTransform = GameManager.instance.player.transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        policeAnimator = GetComponent<Animator>();
        policeAnimator.SetFloat("speed_f", 1);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        enemyAgent.SetDestination(playerTransform.position);
        transform.position = new Vector3(transform.position.x, transform.position.y + offsetY, transform.position.z);
    }
}
