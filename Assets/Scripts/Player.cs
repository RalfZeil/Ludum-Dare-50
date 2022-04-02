using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int sentencedDays;
    private int daysPassed;

    [SerializeField] private int strength;
    [SerializeField] private int intelligence;

    private TextMeshProUGUI sentencedYearsText;

    // Start is called before the first frame update
    void Start()
    {
        sentencedYearsText = GameObject.Find("SentencedYearsText").GetComponent<TextMeshProUGUI>();
        setSentenceText(sentencedDays);
    }

    void setSentenceText(int days) 
    {
        sentencedYearsText.text = days.ToString() + " days";
    }

    void passDay()
    {
        sentencedDays -= 1;
        setSentenceText(sentencedDays);
    }

    public void interacted(int sentenceChange, int strengthChange, int intelligenceChange)
    {
        sentencedDays += sentenceChange;
        strength += strength;
        intelligence += intelligenceChange;

        passDay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
