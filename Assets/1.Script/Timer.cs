using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject bang;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("OnSound", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnSound()
    {
        bang.SetActive(true);
    }
}
