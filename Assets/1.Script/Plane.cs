using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    [SerializeField] private Bang bang;

    private bool t = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (t)
        {
            return;
        }
        transform.Translate(Vector3.forward * Time.deltaTime * 50);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            t = true;
            bang.gameObject.SetActive(true);
        }
    }
}
