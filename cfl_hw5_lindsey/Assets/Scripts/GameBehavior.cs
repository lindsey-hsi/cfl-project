using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    private int marbleHealth = 25;
    private int collectedGoals = 0;
    public int maxGoals = 4;
    public string labelText = "Collect all 4 goals to win!";
    public bool showWinScreen = false;
    public bool showLoseScreen = false;

    public int Goals {
      get { return collectedGoals; }

      set {
        collectedGoals = value; Debug.LogFormat("Goals: {0}", collectedGoals);

        if (collectedGoals >= maxGoals) {
          labelText = "You've collected all goals!";
          showWinScreen = true;
          Time.timeScale = 0f;
        } else {
          labelText = "Goal collected, only " + (maxGoals - collectedGoals) + " more to go!";
        }
      }
    }

    public int Health {
      get { return marbleHealth; }

      set {
        marbleHealth = value; Debug.LogFormat("Marble Health: {0}", marbleHealth);

        if (marbleHealth == 0)
        {
          labelText = "You've lost all your health :(";
          showLoseScreen = true;
          Time.timeScale = 0f;
        }
      }
    }

    void OnGUI() {
      GUI.Box(new Rect(20, 20, 150, 25), "Marble Health: " + marbleHealth);
      GUI.Box(new Rect(20, 50, 150, 25), "Goals Collected: " + collectedGoals);

      GUI.Label(new Rect(Screen.width /2 - 100, Screen.height - 50, 300, 50), labelText);

      if (showWinScreen)
      {
        if (GUI.Button(new Rect(Screen.width/2 - 100, Screen.height/2 - 50, 200, 100), "You Won!"))
        {
          SceneManager.LoadScene(0);
          Time.timeScale = 1.0f;
        }
      }
      if (showLoseScreen)
      {
        if (GUI.Button(new Rect(Screen.width/2 - 100, Screen.height/2 - 50, 200, 100), "You've Lost!"))
        {
          SceneManager.LoadScene(0);
          Time.timeScale = 1.0f;
        }
      }
    }
    // Start is called before the first frame update
    // void Start()
    // {
    //
    // }
    //
    // // Update is called once per frame
    // void Update()
    // {
    //   // Debug.LogFormat("marble health: {0}", marbleHealth);
    // }
}
