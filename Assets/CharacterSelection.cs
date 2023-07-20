using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public Image characterDisplayImage;
    private int currentCharacterIndex;
    public List<CharacterData> characters;

    public class CharacterData
    {
        public string characterName;
        public Sprite characterSprite;
    }

    void Start()
    {
        UpdateCharacterDisplay();
    }

    void UpdateCharacterDisplay()
    {
        // Ensure currentCharacterIndex is within valid range
        currentCharacterIndex = Mathf.Clamp(currentCharacterIndex, 0, characters.Count - 1);

        // Update the character display with the current character sprite
        characterDisplayImage.sprite = characters[currentCharacterIndex].characterSprite;
    }

    public void OnPreviousButtonClicked()
    {
        currentCharacterIndex--;
        UpdateCharacterDisplay();
    }

    public void OnNextButtonClicked()
    {
        currentCharacterIndex++;
        UpdateCharacterDisplay();
    }

    public void OnCharacterClicked()
    {
        CharacterData selectedCharacter = characters[currentCharacterIndex];
        Debug.Log("Selected character: " + selectedCharacter.characterName);
    }

}

