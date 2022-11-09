using UnityEngine;

namespace Ships
{
    public class ViewPortCheckLimits : ICheckLimits
    {
        private readonly Transform _Transform;
        private readonly Camera _camera;
        private readonly float limitMinPosition;
        private readonly float limitMaxPosition;

        public ViewPortCheckLimits(Transform transform, Camera camera, float limitMinPosition, float limitMaxPosition)
        {
            _Transform = transform;
            _camera = camera;
            this.limitMinPosition = limitMinPosition;
            this.limitMaxPosition = limitMaxPosition;
        }
        
        public void ClampFinalPosition()
        {
            var viewportPoint = _camera.WorldToViewportPoint(_Transform.position);
            viewportPoint.x = Mathf.Clamp(viewportPoint.x, limitMinPosition, limitMaxPosition);
            viewportPoint.y = Mathf.Clamp(viewportPoint.y, limitMinPosition, limitMaxPosition);
            _Transform.position = _camera.ViewportToWorldPoint(viewportPoint);
        }
    }
}