using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    NavMeshAgent agent;
    Vector3 randomVector;
    float randomX;
    float randomZ;
    Animator animator;
    bool trigger = false;
    public Player player;
    public ParticleSystem fire;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Player>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        randomX = Random.RandomRange(-200f, 200f);
        randomZ = Random.RandomRange(-200f, 200f);
        randomVector = new Vector3(randomX, 0f, randomZ);
        if (!trigger)
        {
            agent.SetDestination(randomVector);
        }
        if (player.win && !trigger || player.over && !trigger)
        {
            agent.updatePosition = false;
            fire.Play();
            Destroy(gameObject, 2f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "true")
        {
#pragma warning disable CS0618 // Type or member is obsolete
            agent.Stop();
#pragma warning restore CS0618 // Type or member is obsolete
            trigger = true;
            animator.Play("Idle");
            gameObject.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "true")
        {
            if (gameObject.transform.position.y < 0.5f)
            {
                agent.updatePosition = false;
                fire.Play();
                Destroy(gameObject, 3f);
            }
        }
    }

}

