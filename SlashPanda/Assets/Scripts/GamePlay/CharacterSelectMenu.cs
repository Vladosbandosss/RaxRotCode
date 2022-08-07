using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectMenu : MonoBehaviour
{
    [SerializeField] private Button[] charSelectButton;

    [SerializeField] private GameObject[] selectedCharCheckBox;

    public void InitializeCharacterMenu()
    {
        for (int i = 0; i < charSelectButton.Length; i++)
        {
            int charData = DataManager.GetData(TagManager.CHARACTER_DATA + i.ToString());

            if (charData==0)
            {
                charSelectButton[i].interactable = false;
            }
            selectedCharCheckBox[i].SetActive(false);
        }
        
        selectedCharCheckBox[DataManager.GetData(TagManager.SELECTED_CHARACTER_DATA)].SetActive(true);
    }
}
