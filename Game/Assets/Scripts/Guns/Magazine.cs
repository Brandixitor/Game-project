using UnityEngine;

public class Magazine : MonoBehaviour {

    public Gun gun;
    public int Ammo;

    private void OnTriggerEnter(Collider other) {

        if(other.gameObject.tag == "Player") {

            if(Player.instance.CurrentGun != null) {

                if(Player.instance.CurrentGun.name == gun.name) {

                    Player.instance.CurrentGun.AmmoInInventory += Ammo;
                    Destroy(gameObject);

                    Player.instance.UpdateGunUI();

                }

            } else {

                gun.AmmoInInventory += Ammo;
                Destroy(gameObject);

            }

        }

    }

}