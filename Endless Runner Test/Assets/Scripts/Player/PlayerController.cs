using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private StartGame startGame;
    private CapsuleCollider capsule;
    [SerializeField] private Animator anim;

    private Vector3 dir;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;

    private int lineToMove = 1;
    public float lineDistance = 4;
    const float maxSpeed = 80;

    //Animation
    private bool isSliding;

    // Start is called before the first frame update
    void Start()
    {
        startGame = GetComponent<StartGame>();
        controller = GetComponent<CharacterController>();
        capsule = GetComponent<CapsuleCollider>();
    }

    private void Jump()
    {
        dir.y = jumpForce;
        anim.SetTrigger("isJumping");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dir.z = speed;
        dir.y += gravity * Time.fixedDeltaTime;

        controller.Move(dir * Time.deltaTime);
    }

    Coroutine speedPlus;
    private void Update()
    {
        if (startGame != true)
            return;

        if (speedPlus == null)
            speedPlus = StartCoroutine(SpeedIncrease());

        if (SwipeController.swipeRight)
        {
            if (lineToMove < 2)
                lineToMove++;
        }

        if (SwipeController.swipeLeft)
        {
            if (lineToMove > 0)
            {
                lineToMove--;
            }
        }

        if (SwipeController.swipeUp)
        {
            if (controller.isGrounded)
                Jump();
        }

        if (SwipeController.swipeDown)
        {
            StartCoroutine(Slider());
        }

        //Animation 
        if (controller.isGrounded && !isSliding)
            anim.SetBool("isRunning", true);
        else
            anim.SetBool("isRunning", false);

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (lineToMove == 0)
        {
            targetPosition += Vector3.left * lineDistance;
        }else if (lineToMove == 2)
        {
            targetPosition += Vector3.right * lineDistance;
        }

        if (transform.position == targetPosition)
            return;

        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
            controller.Move(moveDir);
        else
            controller.Move(diff);
    }

    private IEnumerator SpeedIncrease()
    {
        yield return new WaitForSeconds(4);

        if (speed < maxSpeed)
        {
            speed += 3f;
            StartCoroutine(SpeedIncrease());
        }
    }

    private IEnumerator Slider()
    {
        capsule.center = new Vector3(0, 0.9f, 0.07f);
        capsule.height = 3;

        if (!controller.isGrounded)
        {
            gravity *= 2.5f;
        }

        isSliding = true;
        anim.SetTrigger("isSliding");

        yield return new WaitForSeconds(1);

        gravity = -25;

        capsule.center = new Vector3(0, 2, 0.07f);
        capsule.height = 5;

        isSliding = false;
    }
}
