﻿using System.Collections.Generic;
using UnityEngine;

namespace DecorPackA.Buildings.MoodLamp
{
    public class GlitterLight2D : KMonoBehaviour, ISim33ms
    {
        [MyCmpReq]
        private Operational operational;

        private Gradient gradient;
        private GradientColorKey[] colorKey;
        private GradientAlphaKey[] alphaKey;

        [MyCmpReq]
        private Light2D light2D;

        private float elapsed = 0f;
        private const float DURATION = 7f;

        protected override void OnPrefabInit()
        {
            base.OnPrefabInit();

            gradient = new Gradient();

            var colors = new List<Color> {
                new Color(2.55f, 0.71f, 0.71f),
                new Color(2.55f, 1.83f, 0.71f),
                new Color(1.24f, 2.30f, 1.27f),
                new Color(.87f, 2.55f, 2.02f),
                new Color(.86f, 1.58f, 2.55f),
                new Color(2.19f, 1.48f, 2.35f),
            };

            colorKey = new GradientColorKey[colors.Count];

            for (var i = 0; i < colors.Count; i++)
            {
                colorKey[i] = new GradientColorKey(colors[i], (i + 1f) / colors.Count);
            }

            alphaKey = new GradientAlphaKey[1];
            alphaKey[0].alpha = 1.0f;
            alphaKey[0].time = 0.0f;

            gradient.SetKeys(colorKey, alphaKey);
        }

        public void Sim33ms(float dt)
        {
            if (!enabled)
            {
                return;
            }

            if (operational.IsOperational)
            {
                elapsed += dt;

                var t = Mathf.Min(elapsed / DURATION, 1f);

                // reverse second half
                if (t > 0.5f)
                {
                    t = 1f - t;
                }

                light2D.Color = gradient.Evaluate(t * 2);

                // reset
                if (elapsed >= DURATION)
                {
                    elapsed = 0f;
                }
            }
        }
    }
}
