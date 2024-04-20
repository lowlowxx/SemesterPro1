using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameSaver : MonoBehaviour
{
    public TMP_InputField SaveNames;



    public void EnterName()
    {
        PlayerPrefs.SetString("PlayerName", SaveNames.ToString());
    }
   
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
