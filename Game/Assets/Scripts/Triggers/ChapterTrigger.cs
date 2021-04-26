using UnityEngine;

public class ChapterTrigger : MonoBehaviour {

    public Chapter chapter;

    private void OnTriggerEnter(Collider other) {

        if(other.gameObject.tag == "Player") {

            StartCoroutine(chapter.SetChapter());

        }

    }

}