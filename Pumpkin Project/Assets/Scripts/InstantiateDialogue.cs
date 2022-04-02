using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;     //запись и чтение xml файла
using System.IO;



public class InstantiateDialogue : MonoBehaviour
{
    
    public TextAsset ta;

    public string objName = "name";

    string MCName = "Pumpkin";
    public Dialog dialogue;
    public int currentNode = 0;
    public bool ShowDialogue = false;
    public GUISkin skin;

    public Texture2D MCportrait;
    public Texture2D NPCportrait;
    /*
    public GameObject Window;


    public Text text;
    public Text firstAnswer;
    public Text secondAnswer;
    public Text thirdAnswer;
    public Button firstButton;
    public Button secondButton;
    public Button thirdButton;

    bool dialogueEnded = false;

    GameObject player;
    

    [SerializeField]
    public int currentNode = 0;
    public int butClicked;
    bool textSet = false;
    Node[] nd;
    */
    void Start()
    {
        dialogue = Dialog.Load(ta);
        foreach(Node nd in dialogue.nodes)
        {
            Debug.Log(nd.Npctext);
            foreach(Answer an in nd.answers)
        {
            Debug.Log(an.text);
            if(an.end)Debug.Log("END");
        }
        }
        
    }

    async void OnGUI()
    {
        GUI.skin = skin;
        if (ShowDialogue) {
            GUI.Label (new Rect (Screen.width  - 1100, Screen.height - 1100, 1600, 1600), MCportrait);
            GUI.Label (new Rect (Screen.width/2 -900, Screen.height - 900, 1100, 1100), NPCportrait);
            GUI.Box (new Rect (Screen.width / 2 - 800, Screen.height - 500, 1600, 500), "");
            GUI.Label (new Rect (Screen.width / 2 - 700, Screen.height - 380, 750, 400), dialogue.nodes [currentNode].Npctext);
            GUI.Label (new Rect (Screen.width / 2 - 700, Screen.height - 440, 1000, 100), objName);
            GUI.Label (new Rect (Screen.width / 2 + 150 , Screen.height - 440 , 1000, 100), MCName);
            for(int i =0;i<dialogue.nodes [currentNode].answers.Length;++i)
            {
                if (GUI.Button (new Rect (Screen.width / 2 + 50, Screen.height - 380 + 95 * i, 750, 95), dialogue.nodes [currentNode].answers [i].text,skin.label)){
                    if(dialogue.nodes [currentNode].answers [i].end) 
                    {
                        ShowDialogue = false;
                        PumpkinController.LockMovement = false;
                    }
                    currentNode = dialogue.nodes [currentNode].answers [i].nextNode;
                }
            }
        }
    }
        /*
        secondButton.enabled = false;
        thirdButton.enabled = false;
        Window.SetActive(false);
        player = GameObject.Find("Player");
        
        nd = dialogue.nodes;


        text.text = nd[currentNode].Npctext;
        firstAnswer.text = nd[currentNode].answers[currentNode].text;

        firstButton.onClick.AddListener(but1);
        secondButton.onClick.AddListener(but2);
        thirdButton.onClick.AddListener(but3);

        AnswerClicked(14);  //14 - для присвоения начальных значений в диалоге что бы не создавать новую функцию
    }

    private void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 1.5f && dialogueEnded == false)
        {
            Window.SetActive(true);
        }
        else
        {
                Window.SetActive(false);

        }
            
    }

    private void but1()
    {
        butClicked = 0;
        AnswerClicked(0);
    }
    private void but2()
    {
        butClicked = 1;
        AnswerClicked(1);
    }
    private void but3()
    {
        butClicked = 2;
        AnswerClicked(2);
    }


    public void AnswerClicked(int numberOfButton)
    {

        if (numberOfButton == 14)
            currentNode = 0;
        else
        {
            if (dialogue.nodes[currentNode].answers[numberOfButton].end == "true")
            {
                dialogueEnded = true;
            }
                
           currentNode = dialogue.nodes[currentNode].answers[numberOfButton].nextNode;
        }

        

        text.text = dialogue.nodes[currentNode].Npctext;

        firstAnswer.text = dialogue.nodes[currentNode].answers[0].text;
        if (dialogue.nodes[currentNode].answers.Length == 2)
        {
            secondButton.enabled = true;
            secondAnswer.text = dialogue.nodes[currentNode].answers[1].text;
        }
        else {
            secondButton.enabled = false;
            secondAnswer.text = "";
        }

        if (dialogue.nodes[currentNode].answers.Length == 3)
        {
            thirdButton.enabled = true;
            thirdAnswer.text = dialogue.nodes[currentNode].answers[2].text;
        }
        else {
            thirdButton.enabled = false;
            thirdAnswer.text = "";
        }


    }
*/
}
