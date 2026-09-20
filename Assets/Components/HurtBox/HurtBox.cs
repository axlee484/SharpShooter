using System;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    public event Action<float> TakeHitEvent;
    public void InvokeTakeHit(float damage)
    {
        TakeHitEvent?.Invoke(damage);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<HitBox>(out var hitBox))
        {
            InvokeTakeHit(hitBox.HitDamage);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //
    }
}
