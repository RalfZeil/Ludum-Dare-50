using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int sentencedDays;
    [SerializeField]private int daysPassed;

    [SerializeField] private int strength;
    [SerializeField] private int intelligence;

    private TextMeshProUGUI sentencedYearsText;
    private TextMeshProUGUI muscleText;

    public Person opponent;

    public GameObject endMenu;
    public TextMeshProUGUI summary;

    // Start is called before the first frame update
    void Start()
    {
        sentencedYearsText = GameObject.Find("SentencedYearsText").GetComponent<TextMeshProUGUI>();
        muscleText = GameObject.Find("MuscleText").GetComponent<TextMeshProUGUI>();
        updateStats();
        endMenu.SetActive(false);
    }

    void setSentenceText(int days) 
    {
        sentencedYearsText.text = days.ToString() + " days";
    }

    void setMuscleText(int str)
    {
        muscleText.text = str.ToString();
    }

    void updateStats()
    {
        setSentenceText(sentencedDays);
        setMuscleText(strength);

        opponent.changeStrength(daysPassed);

        if(sentencedDays < 1)
        {
            endGame();
        }
    }

    public void interacted(int sentenceChange, int strengthChange, int intelligenceChange)
    {
        sentencedDays += sentenceChange;
        strength += strengthChange;
        intelligence += intelligenceChange;

        if(sentenceChange < -1)
        {
            daysPassed += 5;
        }
        else
        {
            daysPassed += 1;
        }
        updateStats();
    }

    public void SetupFight(int opponentStrength)
    {
        FightMessage.ShowFightMessage(strength, opponentStrength);
    }

    public void endGame()
    {
        endMenu.SetActive(true);
        summary.text = "Total days in prison: " + daysPassed.ToString();

        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().StopMusic();
    }

}
