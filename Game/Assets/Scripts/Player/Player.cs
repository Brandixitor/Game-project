using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Player instance;

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBarScript healthBar;

    void start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Awake() {

        if(instance == null) {

            instance = this;

        }

    }

    public Transform EquipPlaceholder;
    public Gun[] Guns;
    public static Gun CurrentGun;
    public static GameObject CurrentGunGO;


    private void Update() {
        //This input is here to make sure the health works
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }

        if(CurrentGun != null) {

            int Index = CurrentGun.Index;

            if(Input.GetAxis("Mouse ScrollWheel") > 0 && Index < Guns.Length - 1) {

                Index++;
                Guns[Index].Equip();

            } else if(Input.GetAxis("Mouse ScrollWheel") < 0) {

                if(Index > 0) {

                    Index--;
                    Guns[Index].Equip();

                }

            }

        }

    }



   void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }






}