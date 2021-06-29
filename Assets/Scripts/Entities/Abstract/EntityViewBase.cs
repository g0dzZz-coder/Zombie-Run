using UnityEngine;

namespace ZombieRun.Entities
{
    [RequireComponent(typeof(Animator))]
    public abstract class EntityViewBase : MonoBehaviour
    {
        [SerializeField] protected Animator animator = null;
    }
}