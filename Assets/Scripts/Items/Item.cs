using UnityEngine;

[CreateAssetMenu(fileName = "New Word", menuName = "Words")]
public class Item : ScriptableObject
{
    new public string name = "New Kanji";
    public string kanaName = "Kana";
    public string kanji = "Symbol";
    public Sprite icon = null;
    public bool isScanned = false;
}
