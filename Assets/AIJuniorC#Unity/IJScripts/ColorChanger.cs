using UnityEngine;

public class ColorChanger
{
    public void Execute(ExplosionCube explosionCube)
    {
        var randomColor = Random.ColorHSV();

        explosionCube.Renderer.material.color = randomColor;
    }
}