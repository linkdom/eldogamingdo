using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    public Sprite selectedCharacterSprite;
    public string selectedCharacterName;

    public void SetSelectedCharacter(Sprite sprite, string name)
    {
        selectedCharacterSprite = sprite;
        selectedCharacterName = name;
    }

    public Sprite GetSelectedCharacterSprite()
    {
        return selectedCharacterSprite;
    }

    public string GetSelectedCharacterName()
    {
        return selectedCharacterName;
    }

}
