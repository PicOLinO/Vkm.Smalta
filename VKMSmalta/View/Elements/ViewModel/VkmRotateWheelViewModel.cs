﻿using DevExpress.Mvvm;
using VKMSmalta.Domain;
using VKMSmalta.Services;

namespace VKMSmalta.View.Elements.ViewModel
{
    public sealed class VkmRotateWheelViewModel : ClickableElementViewModelBase, IValuableNamedElement
    {
        private readonly int rotationStepDegrees;
        private readonly int maxValue;
        private readonly int startupRotation;

        protected override void OnValueChanged()
        {
            base.OnValueChanged();

            RotationDegrees = (Value * rotationStepDegrees) + startupRotation;
        }

        public int RotationDegrees
        {
            get { return GetProperty(() => RotationDegrees); }
            set { SetProperty(() => RotationDegrees, value); }
        }

        public VkmRotateWheelViewModel(int value, string name, int startupRotation, int rotationStepDegrees, int maxValue, HistoryService historyService, string image = "/VKMSmalta;component/View/Images/Wheel.png") : base(value, name, historyService)
        {
            this.startupRotation = RotationDegrees = startupRotation;
            this.rotationStepDegrees = rotationStepDegrees;
            this.maxValue = maxValue;
            ImageSource = image;
            Value = value;
        }

        protected override void OnClick()
        {
            base.OnClick();

            if (Value < maxValue - 1)
            {
                Value += 1;
            }
            else
            {
                Value = 0;
            }
        }
    }
}