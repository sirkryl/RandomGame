using UnityEngine;
using UnityEditor;

//C#
class FitBoxCollider : AssetPostprocessor
{
    void OnPostprocessModel(GameObject g)
    {
        if (!assetPath.Contains("model")) // Just a simple restriction to only process models that contains the word "model" in it's path
            return;                       // without a check it will do the following with every imported asset!
        Renderer[] allRenderers = g.GetComponentsInChildren<Renderer>();
        foreach (Renderer R in allRenderers)
        {
            R.gameObject.AddComponent<BoxCollider>();
        }
    }
}