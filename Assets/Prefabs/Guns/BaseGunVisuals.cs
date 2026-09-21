using Unity.VisualScripting;
using UnityEngine;

public class BaseGunVisuals : MonoBehaviour
{
    [SerializeField] private GameObject muzzleFlashPrefab;
    [SerializeField] private Transform muzzlePosition;
    public readonly string RecoilAnimationName = "Recoil";
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void PlayAnimation(string animationName)
    {
        animator.Play(animationName, 0, 0f);
    }
    public void MuzzleFlash()
    {
        Instantiate(muzzleFlashPrefab, muzzlePosition.transform);
    }
}
