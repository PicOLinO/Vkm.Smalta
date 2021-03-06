﻿#region Usings

using System;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Mvvm;
using Vkm.ComplexSim.Dialogs.ViewModel;

#endregion

namespace Vkm.ComplexSim.Dialogs
{
    public class DialogBase : Window, IDisposable
    {
        protected DialogBase()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ShowInTaskbar = false;
        }

        private void CreateCommands()
        {
            var vm = (DialogViewModelBase) DataContext;
            vm.CloseCommand = new DelegateCommand<bool?>(OnClosing);
        }

        private void OnCloseButtonClick(object sender, RoutedEventArgs e)
        {
            OnClosing();
        }

        protected void Initialize()
        {
            CreateCommands();
        }

        protected virtual void OnClosing(bool? dialogResult = null)
        {
            DialogResult = dialogResult;
            Close();
        }

        public override void OnApplyTemplate()
        {
            if (GetTemplateChild("closeButton") is Button closeButton)
            {
                closeButton.Click += OnCloseButtonClick;
            }

            base.OnApplyTemplate();
        }

        #region IDisposable

        public void Dispose()
        {
            if (GetTemplateChild("closeButton") is Button closeButton)
            {
                closeButton.Click -= OnCloseButtonClick;
            }
        }

        #endregion
    }
}