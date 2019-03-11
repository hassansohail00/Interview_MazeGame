using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject[] wayPoints;
    public int num;
    public GameObject GameOverPanel;
    public float minDist;
    public float speed;

    public bool rand = false;
    public bool go = true;
    Animator anim;
    bool notMove;
    private void Start()
    {
        num = 0;
        anim = GetComponent<Animator>();

    }

    private void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, wayPoints[num].transform.position);
       if (go) {
            if (dist > minDist) {
                Move();
            }
            else
            {
                if (!rand) {
                    if (num+1==wayPoints.Length)
                    {
                        num = 0;
                    }
                    else
                    {
                        num++;
                    }
                }
                else
                {
                    num = Random.Range(0, wayPoints.Length);
                }
            }
        }
    }

    public void Move()
    {
        if (!notMove)
        {
        anim.SetInteger("condiation", 1);
        gameObject.transform.LookAt(wayPoints[num].transform.position);
        gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
        }
    }

    public void Attack() {
        notMove = true;
        print("attach called");
        anim.SetInteger("condiation", 2);
        // Game Over.
        GameObject.Find("GameLose").GetComponent<AudioSource>().Play();

        GameOverPanel.SetActive(true);
    }

    public void Death()
    {
        GameObject.Find("KillSound").GetComponent<AudioSource>().Play();

        notMove = true;
        anim.SetInteger("condiation", 3);
        if (gameObject.name== "StoneMonster")
        {
            transform.GetChild(1).transform.gameObject.SetActive(false);
            transform.GetChild(2).transform.gameObject.SetActive(true);
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
            transform.GetChild(i).transform.gameObject.SetActive(false);
            }
            transform.GetChild(5).transform.gameObject.SetActive(true);
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        //if (other.CompareTag("Sword"))
        //{
        //    /* gameObject.transform.GetChild(0).GetComponent<EnemyAI>().*/
        //    Death();
        //}
        if (other.CompareTag("Kinght"))
        {
            if (other.GetComponent<KnightController>().isAttack)
            {
                Death();
            }
            else
            {
                print("Enter in colidir");
                /*gameObject.transform.GetChild(0).GetComponent<EnemyAI>().*/
                Attack();
            }
           
        }
    }


}
