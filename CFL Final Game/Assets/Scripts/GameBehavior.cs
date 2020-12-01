using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehavior : MonoBehaviour
{
    public Dictionary<string,int> inventory = new Dictionary<string,int>();
    public bool triggerEndPuzzle = false;
    public bool endPuzzleComplete = false;
    public bool displayHint = false;
    public string input1="";
    public string input2="";
    public string input3="";
    public bool button = false;

    void OnGUI() 
    {
        Texture2D texture = new Texture2D(128,128);
        Texture2D texture1 = new Texture2D(128,128);
        Texture2D texture2 = new Texture2D(128,128);

        GUIStyle style = new GUIStyle();
        GUIStyle style1 = new GUIStyle();
        GUIStyle style2 = new GUIStyle();



        for (int y = 0; y < texture.height; ++y)
        {
            for (int x = 0; x < texture.width; ++x)
            {
                texture.SetPixel(x, y, Color.gray);
                texture1.SetPixel(x, y, Color.white);
                texture2.SetPixel(x, y, Color.black);
            }
        }
        texture.Apply();
        texture1.Apply();
        texture2.Apply();
        style.normal.background = texture;
        style.fontSize = 26;
        style.wordWrap = true;
        style.stretchHeight = true;
        style.stretchWidth = true;
        style.alignment = TextAnchor.UpperCenter;
        style1.normal.background = texture1;
        style1.fontSize = 20;
        style1.wordWrap = true;
        style1.stretchHeight = true;
        style1.stretchWidth = true;
        style1.padding = new RectOffset(5,5,5,5);
        style1.alignment = TextAnchor.MiddleCenter;
        style2.normal.background = texture2;
        style2.normal.textColor = Color.white;
        style2.fontSize = 20;
        style2.wordWrap = true;
        style2.stretchHeight = true;
        style2.stretchWidth = true;
        style2.padding = new RectOffset(5,5,5,5);
        style2.alignment = TextAnchor.MiddleCenter;




        GUI.Box(new Rect(15, 25, 160, 175), "–INVENTORY–");
        GUI.Box(new Rect(20, 50, 150, 25), "Periods: " + inventory["."]);
        GUI.Box(new Rect(20, 80, 150, 25), "Exaclamation Points: " + inventory["!"]);
        GUI.Box(new Rect(20, 110, 150, 25), "Question Marks: " + inventory["?"]);
        GUI.Box(new Rect(20, 140, 150, 25), "Commas: " + inventory[","]);
        GUI.Box(new Rect(20, 170, 150, 25), "Sentences: " + inventory["sentence"] +"/1");

        if (triggerEndPuzzle == true) 
        {
            string directions = "To unlock the gate and proceed, arrange the following plot elements in the proper order by typing 1, 2, or 3 into each box. Click on the 'unlock' button when finished.";
            string exposition = "There once was a tin boy named Grey who was lost in a big forest. He was playing outside and wandered too far from home.";
            string risingAction = "The sun was beginning to set and dangerous monsters emerged at night. Grey needed to find his way home soon.";
            string conflict = "All of a sudden, a banshee wailed and began chasing Grey. He didn't know how to react!";

            GUI.Box(new Rect((float)(Screen.width-Screen.width*0.99), (float)(Screen.height-Screen.height*0.99), (float)(Screen.width*0.98), (float)(Screen.height*0.98)), "", style);
            GUI.Box(new Rect((float)(Screen.width-Screen.width*0.95), (float)(Screen.height-Screen.height*0.95), (float)(Screen.width*0.9), 60), directions, style);

            GUI.Box(new Rect((float)(Screen.width-Screen.width*0.90), 350, (float)(Screen.width*.5), 80), exposition, style1);
            GUI.Box(new Rect((float)(Screen.width-Screen.width*0.90), 435, (float)(Screen.width*.5), 25), "exposition");
            input1 = GUI.TextField(new Rect((float)(Screen.width-Screen.width*0.30),350,(float)(Screen.width*.1),80), input1, 1, style1);

            GUI.Box(new Rect((float)(Screen.width-Screen.width*0.90), 200, (float)(Screen.width*.5), 80), risingAction, style1);
            GUI.Box(new Rect((float)(Screen.width-Screen.width*0.90), 285, (float)(Screen.width*.5), 25), "rising action");
            input2 = GUI.TextField(new Rect((float)(Screen.width-Screen.width*0.30),200,(float)(Screen.width*.1),80), input2, 1, style1);

            GUI.Box(new Rect((float)(Screen.width-Screen.width*0.90), 500, (float)(Screen.width*.5), 80), conflict, style1);
            GUI.Box(new Rect((float)(Screen.width-Screen.width*0.90), 585, (float)(Screen.width*.5), 25), "conflict");
            input3 = GUI.TextField(new Rect((float)(Screen.width-Screen.width*0.30),500,(float)(Screen.width*.1),80), input3, 1, style1);
            button = GUI.Button(new Rect((float)(Screen.width-Screen.width*0.6),630,(float)(Screen.width*.2),60), "UNLOCK", style2);
            if (displayHint)
            {
                GUI.Box(new Rect((float)(Screen.width-Screen.width*0.75), 710, (float)(Screen.width*.5), 70), "–HINT– \n1. exposition: provides background information and sets the scene\n2. rising action: builds tension and progresses plot\n3. conflict: presents problem that character must overcome");

            }
        }
        if (button)
        {
            if (input1=="1" && input2=="2" && input3=="3")
            {
                triggerEndPuzzle = false;
                endPuzzleComplete = true;
            } else
            {
                displayHint = true;
            }
        }
        

    }
    // Start is called before the first frame update
    void Start()
    {
        inventory.Add("!",0);
        inventory.Add("?",0);
        inventory.Add(".",0);
        inventory.Add(",",0);
        inventory.Add("sentence",0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
