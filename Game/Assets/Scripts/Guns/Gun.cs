using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public string Name;
    public float Damage, Range = 100, HitForce = 100f, FireRate = 15f, ReloadTime;
    public int AmmoInMagazine, AmmoInInventory, MagazineSize;
    public Sound A_Shot, A_Empty, A_Reload;
    public ParticleSystem MuzzleFlash;
    public GameObject ImpactEffect;
    public Animator animator;
    float NextTimeToFire = 0f;
    AudioSource source;

    private void Update() {

        if(Input.GetMouseButton(0) && Time.time >= NextTimeToFire) {

            NextTimeToFire = Time.time + 1f / FireRate;

            if(AmmoInMagazine > 0) {

                animator.SetBool("Shoot", true);
                StartCoroutine(Shoot());

            } else {

                AudioManager.instance.PlayClip(A_Empty.Name);

            }

        }

        if(Input.GetKeyDown(KeyCode.R) && AmmoInInventory > 0) {

            StartCoroutine(Reload());

        }

    }

    public IEnumerator Shoot() {

        RaycastHit hit;
        AmmoInMagazine--;

        MuzzleFlash.Play();
        AudioManager.instance.PlayClip(A_Shot.Name);
        Player.instance.UpdateGunUI();

        Rigidbody rb = gameObject.GetComponent<Rigidbody>();

        if(Physics.Raycast(Player.instance.Camera.position, Player.instance.Camera.forward, out hit, Range)) {

            Target target = hit.transform.GetComponent<Target>();

            if(target != null) {

                target.Damage(Damage);

            }

            if(hit.rigidbody != null) {

                hit.rigidbody.AddForce(-hit.normal * HitForce);

            }

            GameObject GO = Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(GO, 1);

        }

        yield return new WaitForSeconds(0.2f);

        animator.SetBool("Shoot", false);

    }

    public IEnumerator Reload() {

        int AmmoReload = MagazineSize - AmmoInMagazine;

        if(AmmoInInventory - AmmoReload > 0) {

            Debug.Log(AmmoReload);

            AmmoInInventory -= AmmoReload;
            Player.instance.UpdateGunUI();

            //yield return new WaitForSeconds(ReloadTime);

            AmmoInMagazine += AmmoReload;
            Player.instance.UpdateGunUI();

        } else {

            int ReloadAmount = AmmoInInventory;
            AmmoInInventory = 0;
            Player.instance.UpdateGunUI();

            //yield return new WaitForSeconds(ReloadTime);

            AmmoInMagazine += ReloadAmount;
            Player.instance.UpdateGunUI();

        }

        yield return null;

    }

}