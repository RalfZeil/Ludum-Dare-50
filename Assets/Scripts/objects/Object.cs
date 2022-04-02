using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Object : MonoBehaviour
{
    [SerializeField] protected string desc;
    protected GameObject textBox;
    protected TextMeshPro textMesh;

    [SerializeField] protected string message;
    [SerializeField] protected string promt;

    protected Renderer rend;

    protected Player player;

    protected void Start()
    {
        //Get renderer, textBox object and Text Mesh, then set Text to desc
        rend = GetComponent<Renderer>();
        textBox = this.transform.GetChild(0).gameObject;
        textMesh = this.transform.GetChild(0).GetChild(0).GetComponent<TextMeshPro>();

        textMesh.text = desc;
        textBox.SetActive(false);

        player = GameObject.Find("PlayerManager").GetComponent<Player>();
    }

    protected virtual void OnMouseDown() 
    {
        PopupMessage.ShowPopupMessage(message, promt);
    }

    protected void OnMouseOver()
    {
        rend.material.SetFloat("_Thickness", 0.01f);

        textBox.SetActive(true);
    }

    protected void OnMouseExit()
    {
        rend.material.SetFloat("_Thickness", 0f);

        textBox.SetActive(false);
    }

    public void SetIgnoreRaycast()
    {
        this.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
    }

    public void RemoveIgnoreRaycast()
    {
        this.gameObject.layer = LayerMask.NameToLayer("Default");
    }

}
