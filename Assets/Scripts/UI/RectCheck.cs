using UnityEngine;

public enum IconType
{
    NONE,
    Equipment,
    Skill,
    Inventory,
    Setting,
    Quick,
    Exit
}
public class RectCheck : MonoBehaviour
{
    public IconType iconType;
    private RectTransform rcTransfrom;
    private Rect rc;
    public Rect RC
    {
        get
        {
            rc.x = rcTransfrom.position.x - rcTransfrom.rect.width * 0.5f;
            rc.y = rcTransfrom.position.y + rcTransfrom.rect.height * 0.5f;
            return rc;
        }
    }
    private void Awake()
    {
        rcTransfrom = GetComponent<RectTransform>();
    }
    private void Start()
    {
        rc.x = rcTransfrom.position.x - rcTransfrom.rect.width * 0.5f;
        rc.y = rcTransfrom.position.y + rcTransfrom.rect.height * 0.5f;
        rc.xMin = rcTransfrom.rect.width;
        rc.yMin = rcTransfrom.rect.height;
        rc.width = rcTransfrom.rect.width;
        rc.height = rcTransfrom.rect.height;
    }

    /// <summary>
    /// 매개변수로 전달된 위치가 Rect에 포함되는지 검사
    /// </summary>
    /// <param name="_pos"> 클릭한 위치 </param>
    /// <returns>포함 = true</returns>
    public bool IsInRect(Vector2 _pos)
    {
        if (_pos.x >= RC.x &&
            _pos.x <= RC.x + RC.width &&
            _pos.y <= RC.y &&
            _pos.y >= RC.y - RC.height)
            return true;
        return false;
    }
}
