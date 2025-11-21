using UnityEngine;

public class ScaleChanger
{
    public void Execute(Transform transform)
    {
        int dividerScale = 2;

        var newScale = transform.localScale / dividerScale;
        transform.localScale = newScale;
    }
}