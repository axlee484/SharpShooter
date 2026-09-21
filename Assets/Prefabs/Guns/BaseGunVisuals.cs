using Unity.VisualScripting;
using UnityEngine;

public class BaseGunVisuals : MonoBehaviour
{
    [SerializeField] private GameObject muzzleFlashPrefab;
    [SerializeField] private Transform muzzlePosition;
    public void MuzzleFlash()
    {
        Instantiate(muzzleFlashPrefab, muzzlePosition.transform);
    }
}
