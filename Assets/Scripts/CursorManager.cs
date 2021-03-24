
using UnityEngine;


public class CursorManager  : MonoBehaviour
{
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public Sprite office_Stamp;

    void Start()
    {
        //office_Stamp = UnityEditor.AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/hand.png");
        office_Stamp = Resources.Load<Sprite>("hand");
    }
    public void OnMouseEnter()
    {
        Cursor.SetCursor(office_Stamp.texture, hotSpot, cursorMode);
    }

    public void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}
