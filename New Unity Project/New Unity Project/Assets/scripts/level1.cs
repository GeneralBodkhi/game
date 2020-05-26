using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level1 : MonoBehaviour
{
private float time = 0;
private string text = "";
private GameObject loh=null;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        loh = GameObject.FindWithTag("enemy");
        Debug.Log(loh);

        if (loh == null)
        {
            text = "ПИзда тебе, дурачок";
            
            if (time <= 10.0f)
            {
            time +=Time.deltaTime;
            }
            else
            {
                Application.LoadLevel(2);
            }
        }

        loh = null;
    }
    void OnGUI()
    {

        GUIStyle styleTime = new GUIStyle();
        styleTime.fontSize = 50;
        styleTime.fontStyle = FontStyle.Italic;
        styleTime.normal.textColor = Color.white;
        GUI.Box(new Rect(300, 300, 100, 100), text, styleTime);

    }
}
