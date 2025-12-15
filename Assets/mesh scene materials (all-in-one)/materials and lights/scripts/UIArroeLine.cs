using UnityEngine;

public class UIArrowLine : MonoBehaviour
{
    public LineRenderer line;
    public Transform uiAnchor;
    public Transform buttonAnchor;

    void Update()
    {
        line.SetPosition(0, uiAnchor.position);
        line.SetPosition(1, buttonAnchor.position);
    }
}
