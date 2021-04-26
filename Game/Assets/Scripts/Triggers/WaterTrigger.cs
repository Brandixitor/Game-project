using UnityEngine;

public class WaterTrigger : MonoBehaviour {

    public float WaterStrength;
    public Transform EndPoint;

    private void OnTriggerStay(Collider other) {

        if(other.gameObject.tag == "Player") {

            other.transform.position = Vector3.MoveTowards(other.transform.position, EndPoint.position, WaterStrength * Time.deltaTime);

        }

    }

}