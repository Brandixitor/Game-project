using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    private void Awake() {

        if(instance == null) {

            instance = this;

        }

    }

    public TMP_Text ChapterText;
    public static Chapter CurrentChapter;

}

[System.Serializable]
public class Chapter {

    public string Name;
    public int Index;

    public IEnumerator SetChapter() {

        if(GameManager.CurrentChapter != this) {

            GameManager.CurrentChapter = this;
            GameManager.instance.ChapterText.text = Name;
            GameManager.instance.ChapterText.gameObject.SetActive(true);

            yield return new WaitForSeconds(2.5f);

            GameManager.instance.ChapterText.gameObject.SetActive(false);

        }

    }

}