using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : Singleton<Player>
{
    [SerializeField] private GameObject[] truck;
    [SerializeField] protected Transform AM;
    [SerializeField] private Image deadBody;
    [SerializeField] protected Animator[] playerAM;
    [SerializeField] private SoundPlayer collisionalSound;

    [SerializeField] protected int speed;
    [SerializeField] protected float deadDelayTimer;
    private bool forwar;
    private bool right;
    private bool left;
    private bool stop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameData.gameState != GameData.GameState.Game)
        {
            if (GameData.gameState == GameData.GameState.Dead)
            {
                playerAM[0].enabled = false;
                playerAM[1].enabled = false;
            }
            return;
        }

        //이동
        if (Input.GetKey(KeyCode.W) || forwar)
        {
            transform.rotation = Quaternion.Euler(0, 270, 0);
            playerAM[1].enabled = true;
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            deadDelayTimer = 5f;
            //점수
            GameData.score += 0.025f;
            GameData.carSpeedUpTimer += Time.deltaTime;
            if (GameData.score >= GameData.highestScore)
            {
                PlayerPrefs.SetInt("highestScore", (int)GameData.score);
            }
        }
        else if (Input.GetKey(KeyCode.A) || left && transform.position.z >= -9.5f)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            playerAM[1].enabled = true;
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.D) || right && transform.position.z <= 9.5f)
        {
            transform.rotation = Quaternion.Euler(0, 360, 0);
            playerAM[1].enabled = true;
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || GameData.gameState != GameData.GameState.Game || stop)
        {
            playerAM[1].enabled = false;
            AM.position = new Vector3(transform.position.x, 0, transform.position.z);
        }


        

        //제한시간
        deadDelayTimer -= Time.deltaTime;
        if (deadDelayTimer <= 0)
        {
            //gameObject.SetActive(false);
            GameData.gameState = GameData.GameState.Dead;
            int r = Random.Range(0, truck.Length);
            truck[r].SetActive(true);
        }
    }
    public void ForwardButtonDown()
    {
        forwar = true;
        stop = false;
    }
    public void RightButtonDown()
    {
        right = true;
        stop = false;
    }
    public void LeftButtonDown()
    {
        left = true;
        stop = false;
    }
    public void ButtonUp()
    {
        stop = true;
        forwar = false;
        right = false;
        left = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Car>() || other.GetComponent<Train>())
        {
            GameData.gameState = GameData.GameState.Dead;
            if (PlayerPrefs.GetInt("CSTgl") == 1)
            {
                collisionalSound.gameObject.SetActive(true);
            }
            deadBody.gameObject.SetActive(true);
            deadBody.transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
            gameObject.SetActive(false);
        }
    }
}
