using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Animator playerAnim;
    public bool startGame;

    [Header("UI Elements")]
    [SerializeField] private GameObject scoreText;
    [SerializeField] private GameObject coinText;
    [SerializeField] private GameObject mainText;
    [SerializeField] private Text allMoney;

    // Start is called before the first frame update
    void Start()
    {
        allMoney.gameObject.SetActive(true);
        allMoney.text = "All Money: " + PlayerPrefs.GetInt("coins").ToString();

        scoreText.SetActive(false);
        coinText.SetActive(false);

        mainText.SetActive(true);

        //GameObject.Find("Score Text").GetComponent<Score>().enabled = false;
        this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        this.gameObject.GetComponent<PlayerController>().enabled = false;
    }

    Coroutine goToRun;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && startGame != true)
        {
            playerAnim.SetTrigger("isStanding");

            goToRun = StartCoroutine(GoToRun());
        }
    }

    private IEnumerator GoToRun()
    {
        yield return new WaitForSeconds(1.25f);

        scoreText.SetActive(true);
        coinText.SetActive(true);

        allMoney.gameObject.SetActive(false);
        mainText.SetActive(false);

        //GameObject.Find("Score Text").GetComponent<Score>().enabled = true;
        this.gameObject.GetComponent<CapsuleCollider>().enabled = true;
        this.gameObject.GetComponent<PlayerController>().enabled = true;

        startGame = true;

        StopCoroutine(goToRun);
    }
}
