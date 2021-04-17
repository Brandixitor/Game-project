using UnityEngine;

public class Pickup : MonoBehaviour {

    public Gun gun;

    private void OnTriggerEnter(Collider other) {

        if(other.gameObject.tag == "Player") {

            Destroy(gameObject);
            Player.instance.EquipGun(gun);

        }

    }

}