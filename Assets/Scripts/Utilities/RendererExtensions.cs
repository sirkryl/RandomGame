using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public static class RendererExtensions
{
    public static IEnumerator FlashInColor(this Renderer rend)
    {
        List<Color32> colors = new List<Color32>();

        foreach (Material m in rend.materials)
        {
            colors.Add(m.color);
            //            Material m = rend.material;
            Color32 c = rend.material.color;
            m.color = Color.red;

        }
        yield return new WaitForSeconds(0.1f);

        int cnt = 0;
        foreach (Material m in rend.materials)
        {
            m.color = colors[cnt];
            cnt++;
        }

    }

}

