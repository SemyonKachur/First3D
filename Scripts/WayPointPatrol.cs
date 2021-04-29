using UnityEngine;
using UnityEngine.AI;

public class WayPointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public float stoppingDistance = 0.0f;
    public Transform[] waypoints;
    private GameObject player;
    private EnemyController enemyController = null;
    private Animator _animator = null;
    private float _distance = 0;
    int m_CurrentWaypointIndex;

    void Start()
    {
        _animator = GetComponent<Animator>();
        navMeshAgent.SetDestination(waypoints[0].position);
        stoppingDistance = navMeshAgent.stoppingDistance;
        stoppingDistance = 0.0f;
        player = GameObject.FindGameObjectWithTag("Player");
        enemyController = GetComponent<EnemyController>();
    }

    void Update()
    {
        _distance = enemyController._distance;

            if (_distance < 12)
            {
                _animator.SetBool("Attacking", true);
                navMeshAgent.SetDestination(player.transform.position);
                enemyController.EnemyShooting();
            }
            else
            {
                if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
                {
                    _animator.SetBool("Attacking", false);
                    m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
                    navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
                }
            }
    }

}
