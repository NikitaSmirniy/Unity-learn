using UnityEngine;

public class MonoObjectsSelector
{
    public bool TrySelect<T>(out T selected) where T : MonoBehaviour
    {
        Ray rayDirection = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(rayDirection, out RaycastHit raycastHit))
        {
            if (raycastHit.collider.TryGetComponent(out selected))
                return true;
        }

        selected = null;

        return false;
    }

    public bool TrySelect<T>(out T selected, out RaycastHit raycastHit) where T : MonoBehaviour
    {
        Ray rayDirection = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(rayDirection, out raycastHit))
        {
            if (raycastHit.collider.TryGetComponent(out selected))
                return true;
        }

        selected = null;

        return false;
    }
}