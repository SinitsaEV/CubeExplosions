using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Color GetRandomColor()
    {
        float _red = Random.value;
        float _green = Random.value;
        float _blue = Random.value;

        return new Color( _red, _green, _blue );
    }
}

