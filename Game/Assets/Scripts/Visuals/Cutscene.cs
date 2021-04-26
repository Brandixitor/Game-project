using UnityEngine;

public class Cutscene : MonoBehaviour {

    public Animator animator;
    public bool PlayOnAwake;

    private void Start() {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if(PlayOnAwake) {

            Play();

        }

    }

    void Play() {

        Player.instance.gameObject.SetActive(false);

        animator.SetBool("Play", true);

    }

}