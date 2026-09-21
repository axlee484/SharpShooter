using StarterAssets;
using UnityEngine;

public class Player : MonoBehaviour, IShooter
{
    private StarterAssetsInputs input;
    [SerializeField] private BaseGun gun;
    private void Awake()
    {
        input = GetComponent<StarterAssetsInputs>();
    }

    public void HandleTriggerPress()
    {
        if(gun == null) return;
        gun.SetTrigger(input.Shoot);
    }

    public void HandleReloadPress()
    {
        if(gun == null) return;
        gun.SetReload(input.Reload);
    }
    public void OnShoot()
    {
        HandleTriggerPress();
    }
    public void OnReload()
    {
        HandleReloadPress();
    }
}
