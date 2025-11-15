public class ScaleChanger
{
    public void Execute(ExplosionCube explosionCube)
    {
        int dividerScaleCube = 1;

        var newScale = explosionCube.transform.localScale / dividerScaleCube;
        explosionCube.transform.localScale = newScale;
    }
}