using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject characterSelectMenuPanel;
    [SerializeField] private Text highScoreTxt;

    private CharacterSelectMenu _characterSelect;

    private void Start()
    {
        highScoreTxt.text = "Highscore: " +DataManager.GetData(TagManager.HIGHSCORE_DATA) + "m" ;
        
        _characterSelect = GetComponent<CharacterSelectMenu>();
    }

    public void OpenCloseCharacterMenu(bool open)
    {
        if (open)
        {
            _characterSelect.InitializeCharacterMenu();
        }
        
        characterSelectMenuPanel.SetActive(open);
    }

    public void SelectCharacter()
    {
        int selectedChar = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

        GamePlayController.instance.selectedCharacter = selectedChar;
        
        DataManager.SaveData(TagManager.SELECTED_CHARACTER_DATA,selectedChar);
        
        _characterSelect.InitializeCharacterMenu();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(TagManager.GAMEPLAY_SCENE_NAME);
    }
}
