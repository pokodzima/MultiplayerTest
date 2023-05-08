using Services;
using UnityEngine;
using UnityEngine.EventSystems;

namespace InputHandlers
{

    public class JoystickController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
    {
        private RectTransform _joystickBackground;
        private RectTransform _joystickHandle;
        private Vector3 _inputVector;

        private void Awake()
        {
            _joystickBackground = GetComponent<RectTransform>();
            _joystickHandle = transform.GetChild(0).GetComponent<RectTransform>();
            ServiceLocator.Register<JoystickController>(this);
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 position;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickBackground, eventData.position, eventData.pressEventCamera, out position))
            {
                position.x = (position.x / _joystickBackground.sizeDelta.x);
                position.y = (position.y / _joystickBackground.sizeDelta.y);

                float x = Mathf.Clamp(position.x, -1f, 1f);
                float y = Mathf.Clamp(position.y, -1f, 1f);

                _inputVector = new Vector3(x, 0, y);
                _inputVector = (_inputVector.magnitude > 1.0f) ? _inputVector.normalized : _inputVector;

                // Move the joystick handle
                _joystickHandle.anchoredPosition = new Vector3(_inputVector.x * (_joystickBackground.sizeDelta.x / 3), _inputVector.z * (_joystickBackground.sizeDelta.y / 3));
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnDrag(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _inputVector = Vector3.zero;
            _joystickHandle.anchoredPosition = Vector3.zero;
        }

        public float GetHorizontalInput()
        {
            return _inputVector.x;
        }

        public float GetVerticalInput()
        {
            return _inputVector.z;
        }
    }
}