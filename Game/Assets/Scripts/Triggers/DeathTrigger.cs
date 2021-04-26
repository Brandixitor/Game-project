using UnityEngine;

public class DeathTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {

        if(other.gameObject.tag == "Player") {

            Player.instance.Die();

        }

    }

}