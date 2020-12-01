using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunctuationBehavior : MonoBehaviour
{
    public GameBehavior gameManager;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Character")
        {
            gameManager.inventory[this.gameObject.name] += 1;
            Destroy(this.transform.gameObject);
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
