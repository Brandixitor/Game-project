using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void EquipGun(Gun gun) {

        GameObject GO = Instantiate(gun.gameObject, GunPlaceholder.position, GunPlaceholder.rotation, GunPlaceholder);
        Gun _gun = GO.GetComponent<Gun>();
        
        CurrentGun = _gun;

    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

}