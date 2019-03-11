using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : MonoBehaviour
{
    float speed = 8;
    float rotationSpeed = 100;
    float rotation = 0f;
    float gravity = 5;
    Vector3 moveDir = Vector3.zero;

    CharacterController controller;
    Animator anim;

    public bool isAttack;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Movement();
    }

    void Movement() {
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (anim.GetBool("attacking")== true)
                {
                    return ;
                }
                else
                {
                   // GameObject.Find("Walk").GetComponent<AudioSource>().Play();

                    moveDir = new Vector3(0, 0, 1);
                    moveDir *= speed;
                    moveDir = transform.TransformDirection(moveDir);
                    anim.SetBool("running", true);
                    anim.SetInteger("condiation", 1);
                }
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                moveDir = new Vector3(0, 0, 0);
                anim.SetInteger("condiation", 0);
                anim.SetBool("running", false);
               // GameObject.Find("Walk").GetComponent<AudioSource>().Stop();
            }
        }

        rotation += Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rotation, 0);

        moveDir.y = gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
    }

    void GetInput() {
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (anim.GetBool("running"))
                {
                    anim.SetBool("running", false);
                    anim.SetInteger("condiation", 0);
                }
                 if (anim.GetBool("running")==false)
                {
                    Attacking();
                }
            }
        }
    }

    void Attacking(){
        StartCoroutine(AttackingRouting()); 
    }

    IEnumerator AttackingRouting() {
        anim.SetInteger("condiation", 2);
        anim.SetBool("attacking", true);
        GameObject.Find("Sword").GetComponent<AudioSource>().Play();
        isAttack = true;
        yield return new WaitForSeconds(1);
        isAttack = false;
        anim.SetInteger("condiation",0);
        anim.SetBool("attacking", false);
        GameObject.Find("Sword").GetComponent<AudioSource>().Stop();
    }
}
