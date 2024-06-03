using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class DeadUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreTxt;
    [SerializeField] private TMP_Text highScoreTxt;
    [SerializeField] private TMP_Text loading;
    [SerializeField] private AudioSource deadSound;
    // Start is called before the first frame update
    void Start()
    {
        scoreTxt.text = $"{(int)GameData.score}";
        if (PlayerPrefs.HasKey("highestScore"))
        {
            highScoreTxt.text = $"최고점수 : {PlayerPrefs.GetInt("highestScore")}";
        }
        else
        {
            Debug.LogError("세이브 파일 없음");
        }
        loading.gameObject.SetActive(false);
        if (PlayerPrefs.GetInt("BGSTgl") == 0)
        {
            deadSound.GetComponent<AudioSource>().enabled = false;
        }
        if (PlayerPrefs.GetInt("BGSTgl") == 1)
        {
            deadSound.GetComponent<AudioSource>().enabled = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Screen.SetResolution(460, 850, false);
    }
    public void OnLobby()
    {
        loading.gameObject.SetActive(true);
        SceneManager.LoadScene("Game");
        GameData.gameState = GameData.GameState.Lobby;
    }
}
