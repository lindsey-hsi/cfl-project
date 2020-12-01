using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateBehavior : MonoBehaviour
{
    public GameBehavior gameManager;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Character")
        {
            if (gameManager.inventory["sentence"]<1)
            {
                Debug.Log("You need 1 sentence!");
            } else {
                Debug.Log("Begin end puzzle!");
                gameManager.triggerEndPuzzle = true;
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
        if (gameManager.endPuzzleComplete == true) 
        {
            Destroy(this.transform.parent.gameObject);

        }
    }
}
