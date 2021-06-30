using UnityEngine;
using UnityEngine.AI;

namespace ZombieRun.Entities.Enemies
{
    using Misc;

    public class EnemyMovement : EnemyBehaviorBase
    {
        [SerializeField] private NavMeshAgent _agent = null;
        [SerializeField] private DetectionTrigger _trigger = null;

        private Transform _target;

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

            Source.View.OnRunStarted();
        }

        protected override void OnInited()
        {
            _agent.speed = Source.Data.MoveSpeed;
            _trigger.Setup(Source.Data.detectionRadius);

            _trigger.Detected += SetTarget;
            _trigger.Undetected += RemoveTarget;
        }

        private void RemoveTarget(Transform target)
        {
            _target = null;

            Source.View.OnRunEnded();
        }
    }
}