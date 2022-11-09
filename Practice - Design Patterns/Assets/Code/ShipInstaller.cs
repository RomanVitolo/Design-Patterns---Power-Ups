using System;
using UnityEngine;

namespace Ships
{
    public partial class ShipInstaller : MonoBehaviour
    {
        [SerializeField] private bool _useAI;
        [SerializeField] private bool _usejoystick;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Ship _ship;
        [SerializeField] private float limitMinPosition;
        [SerializeField] private float limitMaxPosition;
        [SerializeField] private float maxDistance;
        private void Awake()
        {
            _ship.Configure(GetInput(), GetCheckLimitsStrategy());
        }

        private ICheckLimits GetCheckLimitsStrategy()
        {
            if (_useAI)
            {
                return new InitialPositionCheckLimits(_ship.transform, maxDistance);
            }
            
            return new ViewPortCheckLimits(_ship.transform, Camera.main, limitMinPosition, limitMaxPosition );
        }
        
        private IInput GetInput()
        {
            if (_useAI)
            {
                return new AIInputAdapter(_ship);
            }
            if (_usejoystick)
            {
                return new JoystickInputAdapter(_joystick);
            }
            
            Destroy(_joystick.gameObject);
            return new UnityInputAdapter();
        }
    }
}