using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour {

    public static Player instance;

    private void Awake() {

        if(instance == null) {

            instance = this;

        }

    }

    //Health Stuff
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBarScript healthBar;

    //Guns Stuff
    public Transform GunPlaceholder;
    public Transform Camera;
    public Gun CurrentGun;
    public TMP_Text Ammo;

    //Movement and Camera stuff
    public bool CanLook = true;
    public bool CanMove = true;

    //Health functions
    void Start()
    {

        if(healthBar != null) {

            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);

        }

        if(CurrentGun == null && Ammo != null) {

            Ammo.gameObject.SetActive(false);

        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    //Guns Functions
    public void EquipGun(Gun gun) {

        if(!Ammo.IsActive()) {

            Ammo.gameObject.SetActive(true);

        }

        GameObject GO = Instantiate(gun.gameObject, GunPlaceholder.position, GunPlaceholder.rotation, GunPlaceholder);
        Gun _gun = GO.GetComponent<Gun>();
        
        CurrentGun = _gun;
        UpdateGunUI();

    }

    public void UpdateGunUI() {

        Ammo.text = CurrentGun.name + ": " + CurrentGun.AmmoInMagazine + "/" + CurrentGun.AmmoInInventory;

    }

}