using StarterAssets;
using UnityEngine;

public class PllayerController : MonoBehaviour
{
    private StarterAssetsInputs input;
    private BaseGun playerGun;
    private void Awake()
    {
        input = GetComponent<StarterAssetsInputs>();
        playerGun = GetComponentInChildren<BaseGun>();
    }

    private void Shoot()
    {
        if(playerGun == null) return;
        playerGun.TryFire();
    }
    private void Update()
    {
        if (input.Shoot)
        {
            Shoot();
            input.ShootInput(false);
        }
    }
}
