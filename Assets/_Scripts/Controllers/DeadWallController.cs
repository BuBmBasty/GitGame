using _Scripts.Abstract;
using Unity.Mathematics;
using UnityEngine;

public class DeadWallController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _deadWallFire;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.gameObject.TryGetComponent<Health>(out var healthController))
        {
            healthController.Dead(5, Vector3.zero);
        }
        else
        {
            other.gameObject.SetActive(false);  
        }
        var fire = Instantiate(_deadWallFire, other.transform);
        fire.Play();
    }

   
}
