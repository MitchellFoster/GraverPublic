using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public Vector2 pointerPosition { get; set; }

    private void Update()
    {
        Vector2 direction = (pointerPosition - (Vector2)transform.position).normalized;
        transform.right = direction;

        Vector2 scale = transform.localScale;
        if (direction.x < 0)
        {
            scale.y = -1;
        }
        else if (direction.x > 0)
        {
            scale.y = 1;
        }
        transform.localScale = scale;
    }
}
