using UnityEngine;

namespace _Scripts.Controllers
{
    public class SimpleCameraController : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        
        private Transform _thisTR;
        private Vector3 _offset;

        private void Start()
        {
            _thisTR = GetComponent<Transform>();
            _offset = _target.position - _thisTR.position;
        }

        private void LateUpdate()
        {
            _thisTR.position = _target.position - _offset;
        }
    }
}
