using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Truck : MonoBehaviour
{
    [SerializeField] private Transform cars;
    [SerializeField] private SoundPlayer collisionalSound;
    [SerializeField] private Image deadBody;
    [SerializeField] private Player p;
    private void Start()
    {
        transform.parent = cars.parent;
        if (PlayerPrefs.GetInt("CSTgl") == 1)
        {
            Invoke("OnSound", 2.3f);
            Invoke("OnDeadBody", 2.8f);
        }
    }
    void OnSound()
    {
        collisionalSound.gameObject.SetActive(true);
    }
    void OnDeadBody()
    {
        deadBody.gameObject.SetActive(true);
        deadBody.transform.position = new Vector3(p.transform.position.x, p.transform.position.y + 0.1f, p.transform.position.z);
        p.gameObject.SetActive(false);
    }
}
