using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    [SerializeField]
    public Text text = null;

    [SerializeField]
    public Image image = null;

    public int a;

    public bool isTrue = false;
   
   void Start()
   {
        if (a == 0)
        {
            return;
        }
        else
        {
            text.text = a.ToString();
        }
        
   }
    void Update()
    {
       
        if (isTrue)
        {
            image.color = Color.red;
        }

    }
}
