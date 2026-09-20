using UnityEngine;
using UnityEngine.AI;

// [RequireComponent(typeof(NavMeshAgent))]
public class BaseEnemy : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform targetTransform;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    public void SetDestination(Vector3 destination)
    {
        navMeshAgent.SetDestination(destination);
    }
    private void Start()
    {
        SetDestination(targetTransform.position);
    }
}
