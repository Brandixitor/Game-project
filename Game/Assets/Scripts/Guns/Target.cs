using UnityEngine;

public class Target : MonoBehaviour {

    public float Health;

    public void Damage(float amount) {

        Health -= amount;

        if(Health < 1) {

            Die();

        }

    }

    public void Die() {

        Destroy(gameObject);

    }

}