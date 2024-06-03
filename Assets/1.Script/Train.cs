using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    [SerializeField] private GameObject track;
    // Start is called before the first frame update
    void Start()
    {
        //trainSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 80);
        if (transform.position.z <= -500)
        {
            transform.position = new Vector3(track.transform.position.x + 0.65f, track.transform.position.y, track.transform.position.z + 99.2f);
        }
    }
}
