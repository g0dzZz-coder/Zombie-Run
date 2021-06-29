using UnityEngine;
using UnityEngine.AI;

namespace ZombieRun.Entities
{
    using Player;
    using Misc;

    [RequireComponent(typeof(Collider))]
    public class EnemyController : EntityControllerBase<EnemyData>
    {
        [SerializeField] private EnemyView _view = null;
        [SerializeField] private NavMeshAgent _agent = null;
        [SerializeField] private DetectionTrigger _trigger = null;

        public float Health { get; private set; }

        private Transform _target;

        private void Start()
        {
            Health = Data.health;

            _agent.speed = Data.movement.moveSpeed.value;
            transform.LookAt(Player.Instance.Root);

            _trigger.Setup(Data.detectionRadius);
            _trigger.Detected += SetTarget;
            _trigger.Undetected += RemoveTarget;

            _view.Init(this);
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

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out StackableCharacterController character))
            {
                character.Die();
            }
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

        //public override void OnDead()
        //{
        //    Destroy(gameObject);
        //}
    }
}