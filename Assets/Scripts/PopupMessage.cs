using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupMessage : MonoBehaviour
{
    public static PopupMessage instance;

    static GameObject popupObject;
    static Button button;
    
    static TextMeshProUGUI contentText;
    static TextMeshProUGUI buttonPromt;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        popupObject = GameObject.Find("PopupMessageUI");
        button = popupObject.transform.GetChild(3).GetComponent<Button>();
        contentText = popupObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        buttonPromt = popupObject.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>();


        ClosePopup();
    }

    public void ClosePopup() 
    {
        popupObject.SetActive(false);

        button.interactable = false;

        Object[] objects = (Object[])GameObject.FindObjectsOfType(typeof(Object));

        foreach (Object ob in objects)
        {
            ob.RemoveIgnoreRaycast();
        }
    }

    public static void ShowPopupMessage(string text, string buttonText) 
    {
        Object[] objects = (Object[])GameObject.FindObjectsOfType(typeof(Object));

        foreach (Object ob in objects)
        {
            ob.SetIgnoreRaycast();
        }

        contentText.text = text;
        buttonPromt.text = buttonText;

        popupObject.SetActive(true);

        instance.StartCoroutine(instance.ExecuteAfterTime(0.5f));
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        button.interactable = true;
    }

}
