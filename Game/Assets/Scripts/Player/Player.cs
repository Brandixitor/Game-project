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

    //Scripts for better access
    public PlayerMovement movement;
    public MouseLook Look;

    //UI Stuff
    public TMP_Text Health;
    public TMP_Text Ammo;

    //Health Stuff
    public int CurrentHealth;
    public int MaxHealth = 100;

    //Guns Stuff
    public Transform GunPlaceholder;
    public Transform Camera;
    public Gun CurrentGun;

    //Movement and Camera stuff
    public bool CanLook = true;
    public bool CanMove = true;

    //Health functions
    public void Damage(int Amount) {

        if(CurrentHealth - Amount > 0) {

            CurrentHealth -= Amount;
            UpdateHealthUI();

        } else {

            CurrentHealth = 0;
            UpdateHealthUI();
            Die();

        }

    }

    public void Die() {

        CanMove = false;
        CanLook = false;

    }

    void Start()
    {

        UpdateHealthUI();

        if(CurrentGun == null && Ammo != null) {

            Ammo.gameObject.SetActive(false);

        }

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

    //UI Functions

    public void UpdateHealthUI() {

        if(Health != null) {

            Health.text = "Health: " + CurrentHealth.ToString() + "/" + MaxHealth.ToString();

        }

    }

    public void UpdateGunUI() {

        Ammo.text = CurrentGun.Name + ": " + CurrentGun.AmmoInMagazine + "/" + CurrentGun.AmmoInInventory;

    }

}