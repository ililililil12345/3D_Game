using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    [SerializeField] private Player p;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameData.gameState == GameData.GameState.Dead)
        {
            return;
        }
        transform.position = new Vector3(p.transform.position.x + 21.2f, p.transform.position.y + 29.48f, p.transform.position.z + 7.68f);
    }
}
