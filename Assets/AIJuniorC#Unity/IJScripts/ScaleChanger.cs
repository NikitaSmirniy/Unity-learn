public class ScaleChanger
{
    public void Execute(ExplosionCube explosionCube)
    {
        int dividerScaleCube = 2;

        var newScale = explosionCube.transform.localScale / dividerScaleCube;
        explosionCube.transform.localScale = newScale;
    }
}
