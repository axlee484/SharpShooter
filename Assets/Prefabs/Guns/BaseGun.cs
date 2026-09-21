using System;
using Unity.VisualScripting;
using UnityEngine;

public class BaseGun : MonoBehaviour
{
    [SerializeField] public GunConfig gunConfig;
    [SerializeField] private Timer fireRateTimer;
    [SerializeField] private Timer reloadTimeTimer;
    public Timer FireRateTimer => fireRateTimer;
    public Timer ReloadTimeTimer => reloadTimeTimer;
    private int bulletsRemaining = 0;
    public int BulletsRemaining => bulletsRemaining;
    public void SetBulletsRemaining(int value) => bulletsRemaining = Math.Clamp(value, 0, gunConfig.MagazineSize);

    private bool isTriggerPressed = false;
    public bool IsTriggerPressed => isTriggerPressed;
    public void SetTrigger(bool value) => isTriggerPressed = value;
    private bool isReloadPressed = false;
    public bool IsReloadPressed => isReloadPressed;
    public void SetReload(bool value) => isReloadPressed = value;
    private bool canShoot = true;
    public bool CanShoot => canShoot;
    public bool SetCanShoot(bool value) => canShoot = value;

    private bool canReload = false;
    public bool CanReload => canReload;
    public bool SetCanReload(bool value) => canReload = value;
    private AudioSource audioSource;
    [SerializeField] private AudioClip shootSound;
    public AudioClip ShootSound => shootSound;
    [SerializeField] private AudioClip reloadSound;
    public AudioClip HitSound => hitSound;
    [SerializeField] private AudioClip hitSound;
    public AudioClip ReloadSound => reloadSound;

    private void SetupSound()
    {
        if(TryGetComponent(out audioSource))
        {
            audioSource.clip = shootSound;
            audioSource.loop = true;
        }
    }
    public void PlaySound(AudioClip clip)
    {
        if(TryGetComponent(out audioSource))
        {
            audioSource.PlayOneShot(clip);
        }
    }

    public void PlayShootSound(bool enabled)
    {
        if(enabled) audioSource.Play();
        else audioSource.Stop();
    }
    private void Awake()
    {
        SetupSound();
        bulletsRemaining = gunConfig.MagazineSize;
        fireRateTimer.SetCountDown(gunConfig.FireRate);
        reloadTimeTimer.SetCountDown(gunConfig.ReloadTime);
    }

}
