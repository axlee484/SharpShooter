using UnityEngine;

public enum GunType
{
    Victini,
    Lucario,
    Dialga
}

[CreateAssetMenu(fileName = "GunConfig", menuName = "Scriptable Objects/GunConfig")]
public class GunConfig : ScriptableObject
{
    [SerializeField] private float damage = 10f;
    public float Damage => damage;
    [SerializeField] private GunType gunType;
    public GunType GunType => gunType;
    [SerializeField] private float recoil = 0.5f;
    public float Recoil => recoil;
    [SerializeField] private float fireRate = 1f;
    public float FireRate => fireRate;
    [SerializeField] private float reloadTime = 1f;
    public float ReloadTime => reloadTime;
    [SerializeField] private int magazineSize = 10;
    public int MagazineSize => magazineSize;
    [SerializeField] private float range = 10f;
    public float Range => range;
    [SerializeField] private bool isAutomatic = true;
    public bool IsAutomatic => isAutomatic;
}
