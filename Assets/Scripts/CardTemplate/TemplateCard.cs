using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard")]
public class TemplateCard : ScriptableObject
{
    public Sprite cardImage;
    public CardType type;
    public CardSubtype subType;

    public void Initialize()
    {
        cardImage = Resources.Load<Sprite>($"CardsBlack/{name}" + "_black");
    }
}
