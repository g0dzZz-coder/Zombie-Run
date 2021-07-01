using UnityEngine;
using UnityEngine.AI;
using System.Collections;

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
            MoveToTarget();
        }

        private void OnDestroy()
        {
            StopAllCoroutines();

            _trigger.Detected -= SetTarget;
            _trigger.Undetected -= RemoveTarget;
            Source.StunStarted -= OnStunStarted;
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
            Source.StunStarted += OnStunStarted;
        }

        private void RemoveTarget(Transform target)
        {
            _target = null;
            _agent.isStopped = true;

            Source.View.OnRunEnded();
        }

        private void MoveToTarget()
        {
            if (_target == null)
                return;

            _agent.SetDestination(_target.position);
        }

        private void OnStunStarted()
        {
            StartCoroutine(WaitForEndOfStun());
        }

        private IEnumerator WaitForEndOfStun()
        {
            _agent.speed = 0;
            yield return new WaitForSeconds(Source.Data.stunDuration);
            _agent.speed = Source.Data.MoveSpeed;

            Source.StunEnded?.Invoke();
        }
    }
}