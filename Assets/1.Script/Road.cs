using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private Player p;
    [SerializeField] private List<GameObject> buildings;
    [SerializeField] private bool buildingRoad;
    [SerializeField] private Coin coin;

    GameObject b;

    // Start is called before the first frame update
    void Start()
    {
        if (buildingRoad)
        {
            b = Instantiate(buildings[Random.Range(0, buildings.Count)], transform.position, Quaternion.identity);
        }
        //内牢 积己
        int coinNum = Random.Range(0, 3);
        for (int i = 0; i < coinNum; i++)
        {
            Coin c = Instantiate(coin, transform.position, Quaternion.identity);
            c.transform.position = new Vector3(transform.position.x + Random.Range(0, 9), 0.01f, transform.position.z + Random.Range(0, 9));
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (p.transform.position.x <= transform.position.x - 30)
        {
            transform.position = new Vector3(transform.position.x - 120, 0, 0);

            //内牢 积己
            int coinNum = Random.Range(0, 3);
            for (int i = 0 ; i < coinNum ; i++)
            {
                if (Pool.Instance.coinPool.Count == 0)
                {
                    Coin c = Instantiate(coin, transform.position, Quaternion.identity);
                    c.transform.position = new Vector3(transform.position.x + Random.Range(0, 9), 0.1f, transform.position.z + Random.Range(0, 9));
                }
                else
                {
                    GameObject c = Pool.Instance.coinPool[Pool.Instance.coinPool.Count - 1];
                    Pool.Instance.coinPool.Remove(c);
                    c.transform.position = new Vector3(transform.position.x + Random.Range(0, 9), 0.1f, transform.position.z + Random.Range(0, 9));
                    c.SetActive(true);
                }
            }

            if (buildingRoad)
            {
                if (b != null)
                {
                    Destroy(b);
                }
                b = Instantiate(buildings[Random.Range(0, buildings.Count)], transform.position, Quaternion.identity);
            }
        }
    }
}
