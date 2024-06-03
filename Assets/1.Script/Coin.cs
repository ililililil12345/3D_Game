using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -3)
        {
            Pool.Instance.InPool(gameObject);
            //Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            GameData.score += 1.5f;
            Pool.Instance.InPool(gameObject);
            //Destroy(gameObject);
        }
    }
}
