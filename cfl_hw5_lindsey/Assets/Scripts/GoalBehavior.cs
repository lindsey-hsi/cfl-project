using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBehavior : MonoBehaviour
{

  public GameBehavior gameManager;

  void Start() {
    gameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
  }

  void OnCollisionEnter(Collision collision) {
    if (collision.gameObject.name == "Marble") {
      Destroy(this.transform.gameObject);
      Debug.Log("Goal collected!");

      gameManager.Goals++;
    }
  }

}
