using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public GameBehavior gameManager;
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision) {
    if (collision.gameObject.name == "Marble") {
      Destroy(this.transform.gameObject);
      Debug.Log("PowerUp Collected!");

      gameManager.Health += 5;
    }
  }
}
