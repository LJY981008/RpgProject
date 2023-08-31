using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum State
{
    Idle,
    Move,
    Attack,
    Die
}
public class SkeletonPattern : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    public Monster skeleton;
    private State state;
    private GameObject player;
    private float speed = 2f;
    private NavMeshAgent agent;
    private float distance;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = Player.Instance.gameObject;
        state = State.Idle;
    }
    private void Update()
    {
        UpdateState();
    }
    public void Die()
    {
        state = State.Die;
    }
    private void UpdateState()
    {
        switch (state)
        {
            case State.Idle:
                {
                    agent.speed = 0f;
                    animator.SetBool("isMove", false);
                    animator.SetBool("isAttack", false);
                    distance = Vector3.Distance(transform.position, player.transform.position);
                    if (distance < 1.5f)
                        state = State.Attack;
                    else if (distance <= 5f)
                        state = State.Move;
                }
                break;
            case State.Move:
                {
                    agent.speed = speed;
                    agent.destination = player.transform.position;
                    animator.SetBool("isMove", true);
                    animator.SetBool("isAttack", false);
                    distance = Vector3.Distance(transform.position, player.transform.position);
                    if (distance < 1.5f)
                        state = State.Attack;
                    else if(distance > 5f)
                        state = State.Idle;
                }
                break;
            case State.Attack:
                {
                    agent.speed = 0f;
                    agent.destination = transform.position;
                    animator.SetBool("isMove", false);
                    animator.SetBool("isAttack", true);
                    skeleton.Attack();
                    distance = Vector3.Distance(transform.position, player.transform.position);
                    if (distance > 1.5f)
                        state = State.Move;
                    else if (distance > 5f)
                        state = State.Idle;
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
