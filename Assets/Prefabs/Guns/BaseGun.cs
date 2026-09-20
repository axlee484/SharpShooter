using UnityEngine;

public class BaseGun : MonoBehaviour
{
    [SerializeField] private GunConfig gunConfig;
    

    public void TryFire()
    {
        bool isHit = Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out var hit, gunConfig.Range);
        if(!isHit) return;
        Debug.Log(hit.collider.gameObject.name);

        if(hit.collider.TryGetComponent<HurtBox>(out var hurtBox))
        {
            hurtBox.InvokeTakeHit(gunConfig.Damage);
        }
    }
}
