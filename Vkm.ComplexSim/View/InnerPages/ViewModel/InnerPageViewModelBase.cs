﻿#region Usings

using System;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using Vkm.ComplexSim.View.Elements.ViewModel;
using Vkm.ComplexSim.View.InnerPages.DSL;

#endregion

namespace Vkm.ComplexSim.View.InnerPages.ViewModel
{
    public class InnerPageViewModelBase : ViewModelBase
    {
        protected InnerPageViewModelBase(Enum pageKey, string backgroundSource)
        {
            PageKey = pageKey;
            BackgroundSource = backgroundSource;
            GiveMe = new GiveMe(pageKey);
        }

        public string BackgroundSource
        {
            get { return GetProperty(() => BackgroundSource); }
            set { SetProperty(() => BackgroundSource, value); }
        }

        public ObservableCollection<ElementViewModelBase> Elements
        {
            get { return GetProperty(() => Elements); }
            set { SetProperty(() => Elements, value); }
        }

        public Enum PageKey { get; }
        protected GiveMe GiveMe { get; }
    }
}