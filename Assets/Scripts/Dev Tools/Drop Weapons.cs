using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;

namespace Dev_Tools
{
    public class DropWeapons : MonoBehaviour
    {
        [SerializeField] private GameObject sniperPrefab, player;
        
        private StarterAssets.StarterAssets _starterAssets;

        private void Awake()
        {
            _starterAssets = GetComponentInParent<StarterAssets.StarterAssets>();
        }

        private void Update()
        {
            DropSniper();
        }

        private void DropSniper()
        {
            if (_starterAssets.dropSniper)
            {
                var sniperRb = Instantiate(sniperPrefab, transform.position, Quaternion.Euler(0f, player.transform.rotation.eulerAngles.y, 0f)).GetComponent<Rigidbody>();
                sniperRb.AddRelativeForce(new Vector3(0f, 0f, 500f));
                _starterAssets.dropSniper = false;
            }
        }
    }
}
