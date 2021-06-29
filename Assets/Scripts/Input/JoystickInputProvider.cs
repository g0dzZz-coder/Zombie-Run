using UnityEngine;

namespace ZombieRun.Input
{
    using Misc;

    public class JoystickInputProvider : MonoBehaviour, IInputProvider
    {
        [SerializeField] private FloatVariable _sensitivity = null;
        [SerializeField] private VariableJoystick _joystick = null;

        private float _input;

        private void Update()
        {
            GetInput();
        }

        public Vector3 GetDirection()
        {
            var direction = new Vector3(1f, 0f, _input).normalized;
            return direction;
        }

        private void GetInput()
        {
            _input = _joystick.Horizontal * _sensitivity.value;
        }
    }
}