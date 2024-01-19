using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    //public Button starButton;
    public TextMeshProUGUI infoPanel;
    public TMP_InputField inputName;
    public TextMeshProUGUI bestScore;
    private bool readyStart;

    private string n_name;
    private int n_score;

    // Start is called before the first frame update
    void Start()
    {
        readyStart = false;
        LoadBest();

        bestScore.text = "Best score : " + Data.Instance.bestPalyerName + " " + Data.Instance.score;
        if (Data.Instance._name != "")
        {
            inputName.text = Data.Instance._name;
        }
    }

    // Update is called once per frame
    void Update()
    {
        string _name = inputName.text;
        if(_name  == "")
        {
            infoPanel.SetText("You must write name to start game");
            readyStart = false;
        }
        else
        {
            infoPanel.SetText("Star game now");
            readyStart = true;
        }

    }

    public void StartGame()
    {
        if (readyStart)
        {
            Data.Instance._name = inputName.text;
            SceneManager.LoadScene(1);
        }
    }

    public void LoadBest()
    {
        Data.Instance.LoadData();
    }

    public void Exit() 
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }


}
