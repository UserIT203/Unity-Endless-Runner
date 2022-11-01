using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Score scoreScripts;
    [SerializeField] private SliderManager sliderManager;
    private PlayerBonus playerBonus;

    [Header("UI Links")]
    [SerializeField] private GameObject losePanel;
    [SerializeField] private Text coinsCountText;

    private int coinsCount;

    // Start is called before the first frame update
    void Start()
    {
        losePanel.SetActive(false);

        coinsCount = PlayerPrefs.GetInt("coins");
        coinsCountText.text = coinsCount.ToString();

        playerBonus = GetComponent<PlayerBonus>();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.gameObject.tag == "Barrier")
        {

            if (playerBonus.isImmortal)
            {
                Destroy(hit.gameObject);
            }
            else
            {
                losePanel.SetActive(true);
                Time.timeScale = 0;

                int lastRunSscore = int.Parse(scoreScripts.scoreText.text);
                PlayerPrefs.SetInt("lastRunScore", lastRunSscore);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coinsCount += 1 * playerBonus.moneyMulti;
            PlayerPrefs.SetInt("coins", coinsCount);

            coinsCountText.text = coinsCount.ToString();

            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "BonusStar")
        {
            Coin bonus = other.GetComponentInChildren<Coin>();
            sliderManager.CreateSlider(bonus.lifeTime, bonus.sliderColor, bonus.bonusName, bonus.bonusSprite);

            if (playerBonus.starCor != null)
                StopCoroutine(playerBonus.starCor);

            playerBonus.starCor = StartCoroutine(playerBonus.StarBonus(bonus.lifeTime));
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "BonusShield")
        {
            Coin bonus = other.GetComponentInChildren<Coin>();
            sliderManager.CreateSlider(bonus.lifeTime, bonus.sliderColor, bonus.bonusName, bonus.bonusSprite);

            if (playerBonus.shieldCor != null)
                StopCoroutine(playerBonus.shieldCor);

            playerBonus.shieldCor = StartCoroutine(playerBonus.ShieldBonus(bonus.lifeTime));
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "MoneyBonus")
        {
            Coin bonus = other.GetComponentInChildren<Coin>();
            sliderManager.CreateSlider(bonus.lifeTime, bonus.sliderColor, bonus.bonusName, bonus.bonusSprite);

            if (playerBonus.moneyMultidCor != null)
                StopCoroutine(playerBonus.moneyMultidCor);

            playerBonus.moneyMultidCor = StartCoroutine(playerBonus.MoneyBonus(bonus.lifeTime));
            Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
