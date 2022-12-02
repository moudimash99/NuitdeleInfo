using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class QuizScript31 : MonoBehaviour
{
    public Button[] buttons;
    //public TextMeshProUGUI b1text;


    void Start()
    {
        buttons = GetComponentsInChildren<Button>();
        foreach(Button button in buttons)
        {
            var b1text = button.GetComponentInChildren<TMP_Text>(true);
            b1text.text = "sdfa";

        }
        //btnValue();
    }

    public void Update()
    {
        buttons = GetComponentsInChildren<Button>();
        foreach (Button button in buttons)
        {
            var b1text = button.GetComponentInChildren<TMP_Text>(true);
            b1text.text = "sdfa";

        }
    }
}
