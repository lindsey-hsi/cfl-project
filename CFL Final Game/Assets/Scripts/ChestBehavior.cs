using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBehavior : MonoBehaviour
{
    public GameBehavior gameManager;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Character")
        {
            if (gameManager.inventory["!"]<1 || gameManager.inventory["?"]<1 || gameManager.inventory["."]<1){
                Debug.Log("You need 1 period, 1 exclamation point, 1 question mark!");
            } else {
                gameManager.inventory["sentence"]+=1;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
