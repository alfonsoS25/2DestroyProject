using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
namespace CameraEffects
{
    public class CameraEffectsScripts
    {
        private Vector3 CameraPos;
        void Start()
        {
            CameraPos = Vector3.zero;
            //StartCourutine()
           
        }
         private IEnumerator ShakeCamera()
        {
            yield return new WaitForSeconds(2);
        }
        private void TranslateCamera()
        {
        }
    }
}
