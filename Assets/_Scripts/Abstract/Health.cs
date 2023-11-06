using UnityEngine;

namespace _Scripts.Abstract
{
  public class Health : MonoBehaviour
  {
    public virtual void Damage(Vector3 direction, float damage)
    {
    
    }
    public virtual void Dead(float damage, Vector3 direction)
    {
    
    }
  }
}
