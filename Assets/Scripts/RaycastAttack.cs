//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections;

//namespace Assets.Scripts
//{
//    public class RaycastAttack : RangedAttack, IHitter
//    {
//        public int hitDamage
//        {
//            get
//            {
//                return damage;
//            }
//            set
//            {
//                damage = value;
//            }
//        }

//        public override void Shoot()
//        {
//            RaycastHit hit;
//            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range, hitMask))
//            {
//                ActivateHittables.HitAll(hit.collider.gameObject, (IHitter)this);
//            }
//        }
//    }
//}
