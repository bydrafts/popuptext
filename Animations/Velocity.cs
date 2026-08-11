using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Scripting;

namespace Drafts.TextPopups.Animations
{
    [Preserve, Serializable]
    public class Velocity : IPopupTextAnimation
    {
        public Vector2 initialMin = new(-10f, 30f);
        public Vector2 initialMax = new(10f, 50f);
        public Vector2 accel = new(0f, -20f);
        public Vector2 clampMin = new(-100f, -100f);
        public Vector2 clampMax = new(100f, 100f);
        public float fontSizeReference = 36f;

        public void ResetText(TMP_Text orig, TMP_Text clone) { }

        public IEnumerator Play(TMP_Text text)
        {
            var scale = text.fontSize / fontSizeReference;
            var currClampMin = clampMin * scale;
            var currClampMax = clampMax * scale;

            var velocity = new Vector2(
                UnityEngine.Random.Range(initialMin.x, initialMax.x),
                UnityEngine.Random.Range(initialMin.y, initialMax.y)
            ) * scale;

            while (text)
            {
                velocity += Time.deltaTime * scale * accel;
                velocity.x = Mathf.Clamp(velocity.x, currClampMin.x, currClampMax.x);
                velocity.y = Mathf.Clamp(velocity.y, currClampMin.y, currClampMax.y);
                text.transform.position += (Vector3)velocity * Time.deltaTime;
                yield return null;
            }
        }
    }
}