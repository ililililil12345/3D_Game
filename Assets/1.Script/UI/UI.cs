using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class UI : MonoBehaviour
{
    [SerializeField] private TMP_Text myScoreTxt;
    [SerializeField] private TMP_Text highScoreTxt;
    [SerializeField] private Image menu;
    [SerializeField] private AudioSource BG;
    [SerializeField] private Toggle BGSTgl;
    [SerializeField] private Toggle CSTgl;
    [SerializeField] private GameObject lobby;


    // Start is called before the first frame update
    void Start()
    {
        GameData.gameState = GameData.GameState.Lobby;
        myScoreTxt.gameObject.SetActive(false);
        GameData.score = 0;

        if (PlayerPrefs.GetInt("BGSTgl") == 1)
        {
            BGSTgl.isOn = true;
        }
        else if (PlayerPrefs.GetInt("BGSTgl") == 0)
        {
            BGSTgl.isOn = false;
        }
        if (PlayerPrefs.GetInt("CSTgl") == 1)
        {
            CSTgl.isOn = true;
        }
        else if (PlayerPrefs.GetInt("CSTgl") == 0)
        {
            CSTgl.isOn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameData.gameState == GameData.GameState.Game)
        {
            myScoreTxt.gameObject.SetActive(true);
        }
        if (GameData.gameState == GameData.GameState.Dead)
        {
            Invoke("OnDead", 4.5f);
        }
        if (GameData.gameState == GameData.GameState.Lobby)
        {
            lobby.SetActive(true);
        }
        else
        {
            lobby.SetActive(false);
        }
        myScoreTxt.text = $"{(int)GameData.score}";
        highScoreTxt.text = $"최고점수 : {PlayerPrefs.GetInt("highestScore")}";

        if (BGSTgl.isOn)
        {
            PlayerPrefs.SetInt("BGSTgl", 1);
        }
        else if (!BGSTgl.isOn)
        {
            PlayerPrefs.SetInt("BGSTgl", 0);
        }
        if (CSTgl.isOn)
        {
            PlayerPrefs.SetInt("CSTgl", 1);
        }
        else if (!CSTgl.isOn)
        {
            PlayerPrefs.SetInt("CSTgl", 0);
        }
        if (PlayerPrefs.GetInt("BGSTgl") == 0)
        {
            BG.gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("BGSTgl") == 1)
        {
            BG.gameObject.SetActive(true);
        }

    }
    public void StartGame()
    {
        GameData.gameState = GameData.GameState.Game;
    }
    public void OnDead()
    {
        SceneManager.LoadScene("Dead");
    }
    public void OnMenu()
    {
        menu.gameObject.SetActive(true);
    }
    public void OffMenu()
    {
        menu.gameObject.SetActive(false);
    }
    public void GetOutApp()
    {
        Application.Quit();
    }
}
