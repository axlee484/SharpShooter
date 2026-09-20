using StarterAssets;
using UnityEngine;

public class PllayerController : MonoBehaviour
{
    private StarterAssetsInputs input;
    private void Awake()
    {
        input = GetComponent<StarterAssetsInputs>();
    }

    private void ShootBullet()
    {
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out var hit, Mathf.Infinity))
        {
            print(hit.collider.gameObject.name);
        }
        input.ShootInput(false);
    }
    private void Update()
    {
        if (input.Shoot)
        {
            ShootBullet();
        }
    }
}
