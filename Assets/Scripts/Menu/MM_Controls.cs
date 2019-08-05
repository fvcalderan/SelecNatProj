using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MM_Controls : MonoBehaviour
{

    private Button BTN_Start;
    private Button BTN_Quit;

    private InputField input_EttQtty;
    private InputField input_SimTime;
    private InputField input_SimSpeed;
    private InputField input_FoodSpeed;
    private InputField input_FoodQtty;

    private Dropdown drop_Map;

    private GameObject MapConfig;

    // Start is called before the first frame update
    void Start()
    {
        BTN_Start = GameObject.Find("BTN_Start").GetComponent<Button>();
        BTN_Quit = GameObject.Find("BTN_Quit").GetComponent<Button>();

        input_EttQtty = GameObject.Find("input_EttQtty").GetComponent<InputField>();
        input_SimTime = GameObject.Find("input_SimTime").GetComponent<InputField>();
        input_SimSpeed = GameObject.Find("input_SimSpeed").GetComponent<InputField>();
        input_FoodSpeed = GameObject.Find("input_FoodSpeed").GetComponent<InputField>();
        input_FoodQtty = GameObject.Find("input_FoodQtty").GetComponent<InputField>();

        drop_Map = GameObject.Find("drop_Map").GetComponent<Dropdown>();

        MapConfig = GameObject.Find("MapConfig");


        BTN_Start.onClick.AddListener(BTN_Start_on_Click);
        BTN_Quit.onClick.AddListener(BTN_Quit_on_Click);
    }

    void BTN_Start_on_Click()
    {
        DontDestroyOnLoad(MapConfig.gameObject);

        MapConfig.GetComponent<MM_MapConfig>().MapName = drop_Map.options[drop_Map.value].text;
        MapConfig.GetComponent<MM_MapConfig>().EttQtty = int.Parse(input_EttQtty.text);
        MapConfig.GetComponent<MM_MapConfig>().SimTime = float.Parse(input_SimTime.text, CultureInfo.InvariantCulture);
        MapConfig.GetComponent<MM_MapConfig>().SimSpeed = int.Parse(input_SimSpeed.text);
        MapConfig.GetComponent<MM_MapConfig>().FoodSpeed = float.Parse(input_FoodSpeed.text, CultureInfo.InvariantCulture);
        MapConfig.GetComponent<MM_MapConfig>().FoodQtty = int.Parse(input_FoodQtty.text);

        SceneManager.LoadScene(drop_Map.options[drop_Map.value].text);

    }

    void BTN_Quit_on_Click()
    {
        //Ignored while inside Editor
        Application.Quit();
    }


}
