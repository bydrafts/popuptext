using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Scripting;

namespace Drafts.TextPopups.Animations
{
    [Preserve, Serializable]
    public class Random : IPopupTextAnimation
    {
        public Vector2 minPosition = new(-20, -20);
        public Vector2 maxPosition = new(20, 20);
        public Vector2 rotation = Vector2.zero;
        public float fontSizeReference = 36f;

        public void ResetText(TMP_Text orig, TMP_Text clone)
        {
            clone.transform.rotation = orig.transform.rotation;
        }

        public IEnumerator Play(TMP_Text text)
        {
            var scale = text.fontSize / fontSizeReference;
            var offset = new Vector3(
                UnityEngine.Random.Range(minPosition.x, maxPosition.x),
                UnityEngine.Random.Range(minPosition.y, maxPosition.y),
                0) * scale;

            var rot = text.transform.rotation.eulerAngles;
            rot.z = UnityEngine.Random.Range(rotation.x, rotation.y);
            text.transform.rotation = Quaternion.Euler(rot);
            text.transform.position += offset;
            yield break;
        }
    }
}