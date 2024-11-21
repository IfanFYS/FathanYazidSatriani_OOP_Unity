using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private Weapon weaponHolder;  // Prefab Weapon yang akan diambil
    private Weapon weapon;

    private void Awake()
    {
        weapon = weaponHolder;
    }

    private void Start()
    {
        if (weapon != null)
        {
            // Turnvisual(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Cek apakah Player sudah memiliki weapon
            Weapon existingWeapon = other.GetComponentInChildren<Weapon>();
            
            if (existingWeapon != null)
            {
                // Jika sudah ada, hapus weapon lama
                Destroy(existingWeapon.gameObject);
            }

            // Instantiate weapon baru sebagai child dari Player
            Weapon newWeapon = Instantiate(weaponHolder, other.transform);
            newWeapon.transform.localPosition = Vector3.zero; // Set posisi relatif sesuai kebutuhan
            Turnvisual(true);
        }
    }

    private void Turnvisual(bool enable)
    {
        // Mengaktifkan atau menonaktifkan komponen Renderer pada WeaponPickup
        foreach (var component in GetComponentsInChildren<Renderer>())
        {
            component.enabled = enable;
        }
    }
}