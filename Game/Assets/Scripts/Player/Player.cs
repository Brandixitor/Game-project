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

    public Transform EquipPlaceholder;
    public Gun[] Guns;
    public static Gun CurrentGun;
    public static GameObject CurrentGunGO;

    private void Update() {

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

}