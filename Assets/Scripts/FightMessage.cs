using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FightMessage : MonoBehaviour
{
    public static FightMessage instance;

    static GameObject MessageObject;
    static Button button;

    static TextMeshProUGUI strengthText;
    static TextMeshProUGUI winChanceText;
    static TextMeshProUGUI oppoStrengthText;

    private static int tempStrength;
    private static int tempOppoStrength;

    public Player player;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        MessageObject = GameObject.Find("FightMessage");
        button = MessageObject.transform.GetChild(5).GetComponent<Button>();
        strengthText = MessageObject.transform.GetChild(3).GetChild(1).GetComponent<TextMeshProUGUI>();
        winChanceText = MessageObject.transform.GetChild(3).GetChild(2).GetComponent<TextMeshProUGUI>();
        oppoStrengthText = MessageObject.transform.GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>();

        player = GameObject.Find("PlayerManager").GetComponent<Player>();


        ClosePopup();
    }

    public void ClosePopup()
    {
        MessageObject.SetActive(false);

        button.interactable = false;

        Object[] objects = (Object[])GameObject.FindObjectsOfType(typeof(Object));

        foreach (Object ob in objects)
        {
            ob.RemoveIgnoreRaycast();
        }
    }

    public static void ShowFightMessage(int strength, int opponentStrength)
    {
        Object[] objects = (Object[])GameObject.FindObjectsOfType(typeof(Object));

        foreach (Object ob in objects)
        {
            ob.SetIgnoreRaycast();
        }

        tempStrength = strength;
        tempOppoStrength = opponentStrength;

        strengthText.text = "Strength: " + strength.ToString();
        winChanceText.text = "Win chance: " + calculateWinChance(strength, opponentStrength).ToString() + "%";

        oppoStrengthText.text = "Strength: " + opponentStrength.ToString();

        MessageObject.SetActive(true);

        instance.StartCoroutine(instance.ExecuteAfterTime(0.5f));
    }

    public void fight()
    {
        if (Random.Range(0, 100) > calculateWinChance(tempStrength, tempOppoStrength))
        {
            player.interacted(-5, 0, 0);
            PopupMessage.ShowPopupMessage("You lost and recovered for 5 days in the infirmary!", "Oof");
        }
        else
        {
            player.interacted(+2, 0, 0);
            PopupMessage.ShowPopupMessage("You won and are sentenced 2 more days in jail!", "Sweet");
        }

        ClosePopup();

    }

    static int calculateWinChance(int strength, int opponentStrength)
    {
        if (strength > opponentStrength) return 80;

        else
        {
            float chance = ((float)strength / (float)opponentStrength) * 100;
            if (chance > 80) return 80;
            else
            {
                return (int)chance;
            }
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        button.interactable = true;
    }
}
