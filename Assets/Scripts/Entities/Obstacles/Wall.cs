using UnityEngine;

namespace ZombieRun.Entities
{
    public class Wall : MonoBehaviour
    {
        [SerializeField] private Vector2 _heigth = new Vector2(5, 10);

        private void Awake()
        {
            SetRandomHeight();
        }

        private void SetRandomHeight()
        {
            var randomHeigth = Random.Range(_heigth.x, _heigth.y);
            transform.localScale = new Vector3(transform.localScale.x, randomHeigth, transform.localScale.z);
        }
    }
}