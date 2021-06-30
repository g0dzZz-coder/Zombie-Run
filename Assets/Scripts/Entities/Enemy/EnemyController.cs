using UnityEngine;
using UnityEngine.AI;

namespace ZombieRun.Entities
{
    using Misc;
    using Player;

    [RequireComponent(typeof(Collider))]
    public class EnemyController : EntityControllerBase<EnemyData>
    {
        [SerializeField] private EnemyView _view = null;
        [SerializeField] private Health _health = null;
        [SerializeField] private NavMeshAgent _agent = null;
        [SerializeField] private DetectionTrigger _trigger = null;

        private Transform _target;

        private void Start()
        {
            _agent.speed = Data.MoveSpeed;
            transform.LookAt(Player.Instance.Root);

            _view.Init(this);

            _health.Init(Data.health);
            _health.DamageTaked += _view.OnDamageTaked;

            _trigger.Setup(Data.detectionRadius);
            _trigger.Detected += SetTarget;
            _trigger.Undetected += RemoveTarget;
        }

        private void Update()
        {
            if (_target == null)
                return;

            _agent.SetDestination(_target.position);
        }

        private void OnDestroy()
        {
            _trigger.Detected -= SetTarget;
            _trigger.Undetected -= RemoveTarget;
        }

        public void SetTarget(Transform target)
        {
            _target = target;
            _view.OnRunStarted();
        }

        private void RemoveTarget(Transform target)
        {
            _target = null;
            _view.OnRunEnded();
        }
    }
}