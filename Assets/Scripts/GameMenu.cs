using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public GameObject theMenu;
    public GameObject[] windows;
    private CharStats[] playerStats;

    public Text[] nameText, hpText, mpText, lvlText, expText;
    public Slider[] expSlider;
    public Image[] charImage;
    public GameObject[] charStatHolder;

    public GameObject[] statButtons;

    public Text statName, statHP, statMP, statStr, statDef, statWpnEqp, statWpnPwr, statArmrEqp, statArmrPwr, statExp;
    public Image statImage;

    public ItemButton[] itemButtons;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (theMenu.activeInHierarchy)
            {
                //theMenu.SetActive(false);
                //  GameManager.instance.gameMenuOpen = false;
                CloseMenu();
            }
            else
            {
                theMenu.SetActive(true);
                UpdateMainStats();
                GameManager.instance.gameMenuOpen = true;

            }
        }
    }

    public void UpdateMainStats()
    {
        playerStats = GameManager.instance.playerStats;

        for (int i = 0; i < playerStats.Length; i++)
        {
            if (playerStats[i].gameObject.activeInHierarchy)
            {
                charStatHolder[i].SetActive(true);
                nameText[i].text = playerStats[i].charName;
                hpText[i].text = "HP: " + playerStats[i].currentHP + "/" + playerStats[i].maxHP;
                mpText[i].text = "MP: " + playerStats[i].currentMP + "/" + playerStats[i].maxMP;
                lvlText[i].text = "Lvl :" + playerStats[i].playerLevel;
                expText[i].text = "" + playerStats[i].currentEXP + "/" + playerStats[i].expToNextLevel[playerStats[i].playerLevel];
                expSlider[i].maxValue = playerStats[i].expToNextLevel[playerStats[i].playerLevel];
                expSlider[i].value = playerStats[i].currentEXP;
                charImage[i].sprite = playerStats[i].charImg;
            }
            else
            {
                charStatHolder[i].SetActive(false);
            }
        }

    }
    public void ToggleWindow(int windowNumber)
    {
        UpdateMainStats();

        for (int i = 0; i < windows.Length; i++)
        {
            if (i == windowNumber)
            {
                windows[i].SetActive(!windows[i].activeInHierarchy);
            }
            else
            {
                windows[i].SetActive(false);
            }
        }
    }
    public void CloseMenu()
    {
        for (int i = 0; i < windows.Length; i++)
        {
            windows[i].SetActive(false);

        }
        theMenu.SetActive(false);
        GameManager.instance.gameMenuOpen = false;
    }

    public void OpenStats()
    {
        UpdateMainStats();
        StatChar(0);


        for (int i = 0; i < statButtons.Length; i++)
        {
            statButtons[i].SetActive(playerStats[i].gameObject.activeInHierarchy);
            statButtons[i].GetComponentInChildren<Text>().text = playerStats[i].charName;
        }

    }
    public void StatChar(int selected)
    {
        statName.text = playerStats[selected].charName;
        statHP.text = "" + playerStats[selected].currentHP + "/" + playerStats[selected].maxHP;
        statMP.text = "" + playerStats[selected].currentMP + "/" + playerStats[selected].maxMP;
        statStr.text = playerStats[selected].strength.ToString();
        statDef.text = playerStats[selected].defence.ToString();

        if (playerStats[selected].equippedWpn != "")
        {
            statWpnEqp.text = playerStats[selected].equippedWpn;
        }
        statWpnPwr.text = playerStats[selected].wpnPwr.ToString();
        if (playerStats[selected].equippedArmr != "")
        {
            statArmrEqp.text = playerStats[selected].equippedArmr;
        }
        statArmrPwr.text = playerStats[selected].armrPwr.ToString();
        statExp.text = (playerStats[selected].expToNextLevel[playerStats[selected].playerLevel] - playerStats[selected].currentEXP).ToString();
        statImage.sprite = playerStats[selected].charImg;

    }

    public void ShowItems()
    {

        GameManager.instance.SortItems();
        for (int i = 0; i < itemButtons.Length; i++)
        {
            itemButtons[i].buttonValue = i;
            if (GameManager.instance.itemsHeld[i] != "")
            {

                itemButtons[i].buttonImage.gameObject.SetActive(true);
                itemButtons[i].buttonImage.sprite = GameManager.instance.GetItemDetails(GameManager.instance.itemsHeld[i]).itemSprite;
                itemButtons[i].amountText.text = GameManager.instance.numberOfItems[i].ToString();

            }
            else
            {
                itemButtons[i].buttonImage.gameObject.SetActive(false);
                itemButtons[i].amountText.text = "";
            }
        }
    }

}
