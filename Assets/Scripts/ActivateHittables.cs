//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections;

//public class ActivateHittables
//{
//    // Hit all of the hittables attached to a game object
//    public static void HitAll(GameObject gameObject, IHitter hitter)
//    {
//        // Get the hittable components
//        Component[] hittables = gameObject.GetComponents(typeof(IHittable));

//        if (hittables == null)
//        {
//            return;
//        }

//        // Hit all of the hittables
//        foreach (IHittable hittable in hittables)
//        {
//            hittable.Hit(hitter);
//        }
//    }
//}