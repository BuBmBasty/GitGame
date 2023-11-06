using UnityEngine;

namespace _Scripts.Controllers
{
    public class CinematicCameraTransform : MonoBehaviour
    {
        public Transform target;

        // Update is called once per frame
        void LateUpdate()
        {
            transform.position = target.position -10 * Vector3.forward;
            transform.rotation = target.rotation;
        }
    }
}
