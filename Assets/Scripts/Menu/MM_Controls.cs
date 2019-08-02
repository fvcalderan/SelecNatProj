using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MM_Controls : MonoBehaviour
{

    public Button BTN_Start;
    public Button BTN_Quit;

    public Dropdown drop_Map;

    // Start is called before the first frame update
    void Start()
    {
        BTN_Start.onClick.AddListener(BTN_Start_on_Click);
        BTN_Quit.onClick.AddListener(BTN_Quit_on_Click);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BTN_Start_on_Click()
    {
        SceneManager.LoadScene(drop_Map.options[drop_Map.value].text);
    }

    void BTN_Quit_on_Click()
    {
        //Ignored while inside Editor
        Application.Quit();
    }


}
