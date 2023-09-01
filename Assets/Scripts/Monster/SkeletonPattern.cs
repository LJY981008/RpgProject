using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum State
{
    Idle,
    Move,
    Repos,
    Attack,
    Die
}
public class SkeletonPattern : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    public Monster skeleton;
    private State state;
    private NavMeshAgent agent;
    private GameObject player;
    private float speed = 2f;
    private float attackDelay = 2f;
    private float timer = 2f;
    private float toPlayerDistance;
    private float toSpawnDistance;
    private Vector3 spawnPos;
    private void Awake()
    {
        spawnPos = transform.position;
        agent = GetComponent<NavMeshAgent>();
        player = Player.Instance.gameObject;
        state = State.Idle;
    }
    private void Update()
    {
        toSpawnDistance = Vector3.Distance(transform.position, spawnPos);
        if(toSpawnDistance > 7f)
        {
            state = State.Repos;
        }
        UpdateState();
    }
    public void Die()
    {
        state = State.Die;
    }
    private void UpdateState()
    {
        timer += Time.deltaTime;
        switch (state)
        {
            case State.Idle:
                {
                    agent.speed = 0f;
                    animator.SetBool("isMove", false);
                    animator.SetBool("isAttack", false);
                    toPlayerDistance = Vector3.Distance(transform.position, player.transform.position);
                    if (toPlayerDistance < 1.5f)
                        state = State.Attack;
                    else if (toPlayerDistance <= 5f)
                        state = State.Move;
                }
                break;
            case State.Move:
                {
                    agent.speed = speed;
                    agent.destination = player.transform.position;
                    animator.SetBool("isMove", true);
                    animator.SetBool("isAttack", false);
                    toPlayerDistance = Vector3.Distance(transform.position, player.transform.position);
                    if (toPlayerDistance < 1.5f)
                    {
                        state = State.Attack;
                    }
                    else if (toPlayerDistance > 5f)
                        state = State.Idle;
                }
                break;
            case State.Attack:
                {
                    agent.speed = 0f;
                    agent.destination = transform.position;
                    animator.SetBool("isMove", false);
                    if (timer > attackDelay)
                    {
                        timer = 0f;
                        animator.SetBool("isAttack", true);
                    }
                    else
                    {
                        animator.SetBool("isAttack", false);
                    }
                    toPlayerDistance = Vector3.Distance(transform.position, player.transform.position);
                    if (toPlayerDistance > 1.5f)
                        state = State.Move;
                    else if (toPlayerDistance > 5f)
                        state = State.Idle;
                }
                break;
            case State.Repos:
                {
                    agent.speed = speed;
                    agent.destination = spawnPos;
                    animator.SetBool("isMove", true);
                    animator.SetBool("isAttack", false);
                }
                break;
            case State.Die:
                {
                    agent.speed = 0;
                    agent.destination = transform.position;
                    animator.Play("Die");
                }
                break;
            default:
                break;
        }
    }
}
