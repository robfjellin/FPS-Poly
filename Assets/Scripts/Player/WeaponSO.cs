using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    public GameObject WeaponPrefab;
    public int Damage = 1;
    public float FireRate = 0.5f;
    public GameObject HitVFXPrefab;
    public bool IsAutomatic, CanZoom;
    public float ZoomAmount = 10f;
    public float ZoomRotationSpeed = .3f;
    [FormerlySerializedAs("magazineSize")] public int MagazineSize = 12;
}
