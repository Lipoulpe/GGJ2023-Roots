using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField] Transform _Canvas;

    SeedAttribute _seedSelected;
    public void OnClick(GameObject go)
    {
        print(go.name + " selected");
    }

    public void OnBeginDrag(SeedAttribute seed)
    {
        _seedSelected = Instantiate(seed,_Canvas);
        RectTransform rt = (RectTransform)_seedSelected.transform;

        rt.sizeDelta = new Vector2(128f, 128f);
        _seedSelected.Image.raycastTarget = false;
    }

    public void OnDrag()
    {
        _seedSelected.transform.position = Input.mousePosition;
    }

    public void OnEndDrag()
    {
        Destroy(_seedSelected.gameObject);
    }

    public void OnDrop(SeedAttribute seed)
    {
        seed.SetSeed(_seedSelected);
    }
}
