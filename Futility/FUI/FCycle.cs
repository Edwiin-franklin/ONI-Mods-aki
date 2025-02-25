﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace FUtility.FUI
{
    public class FCycle : KMonoBehaviour
    {
        public event System.Action OnChange;

        [SerializeField]
        public FButton leftArrow;

        [SerializeField]
        public FButton rightArrow;

        [SerializeField]
        public LocText label;

        [SerializeField]
        public LocText description;

        private int currentIndex = 0;

        [SerializeField]
        public List<Option> Options;

        [Serializable]
        public class Option
        {
            public string id;
            public string title;
            public string description;

            public Option(string id, string title, string description)
            {
                this.id = id;
                this.title = title;
                this.description = description;
            }
        }

        public void Initialize(FButton leftButton, FButton rightButton, LocText label, LocText description = null)
        {
            leftArrow = leftButton;
            rightArrow = rightButton;

            this.label = label;
            this.description = description;

            leftArrow.OnClick += CycleLeft;
            rightArrow.OnClick += CycleRight;
        }

        private bool HasOptions => Options.Count > 0;

        public string Value
        {
            get => Options.Count >= currentIndex ? Options[currentIndex].id : default;

            set {

                int idx = Options.FindIndex(x => x.id == value);
                if (idx != -1)
                {
                    currentIndex = idx;
                    UpdateLabel();
                }
                else
                {
                    Log.Warning($"Invalid option ID given \"{value}\"");
                }
            }
        }

        public void CycleLeft()
        {
            if (HasOptions)
            {
                currentIndex = (currentIndex + Options.Count - 1) % Options.Count;
                UpdateLabel();
                OnChange?.Invoke();
            }
        }
        public void CycleRight()
        {
            if (HasOptions)
            {
                currentIndex = (currentIndex + 1) % Options.Count;
                UpdateLabel();
                OnChange?.Invoke();
            }
        }

        private void UpdateLabel()
        {
            if (Options.Count >= currentIndex)
            {
                Value = Options[currentIndex].id;

                label.SetText(Options[currentIndex].title);

                if (description != null)
                {
                    description.SetText(Options[currentIndex].description);
                }
            }
        }
    }
}
