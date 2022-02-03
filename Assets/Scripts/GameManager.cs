using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isGameOver;

    [SerializeField]
    GameObject playerModel;

    [SerializeField]
    GameObject restartUI;
    [SerializeField]
    TextMeshProUGUI restartLabel;

    [SerializeField]
    TextMeshProUGUI coinsLabel;

    private int coins = 0;


    private const string WIN_TEXT = "Victory!";
    private const string LOSE_TEXT = "Defeat!";

    public void Awake()
    {
        Instance = this;
        coins = 0;
    }

    public void HandleGameOver() {
        isGameOver = true;
        restartLabel.text = LOSE_TEXT;
        ChangeAnimation("Death", "Eyes_Dead");
        StartCoroutine(WaitAndShowRestart());

    }
    public void HandleWin()
    {
        restartLabel.text =WIN_TEXT;
        ChangeAnimation("Jump", "Eyes_Happy");
        StartCoroutine(WaitAndShowRestart());

    }
    public void HandleCoin()
    {
        coins++; 
        coinsLabel.text = coins.ToString();

    }
    public IEnumerator WaitAndShowRestart()
    {

        yield return new WaitForSeconds(2f);
        restartUI.SetActive(true);
    }
    public void Restart()
    {


        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void ChangeAnimation(string bodyAnimation,string eyesAnimation)
    {


        int count = playerModel.transform.childCount;
        for (int i = 0; i < count; i++)
        {


            playerModel.transform.GetChild(i).GetComponent<Animator>()?.Play(bodyAnimation);
            playerModel.transform.GetChild(i).GetComponent<Animator>()?.Play(eyesAnimation);

        }


    }
}
