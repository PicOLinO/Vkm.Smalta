﻿#region Usings

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using DevExpress.Mvvm;
using Vkm.ComplexSim.Dialogs.ViewModel;
using Vkm.ComplexSim.Domain;

#endregion

namespace Vkm.ComplexSim.Dialogs.Factories
{
    public class DialogFactory : IDialogFactory
    {
        private readonly IMessageBoxService service;

        public DialogFactory(IMessageBoxService service)
        {
            this.service = service;
        }

        #region IDialogFactory

        public bool AskYesNo(string text, string caption = null)
        {
            var result = service.Show(text, caption ?? "Вы уверены?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            return result == MessageBoxResult.Yes;
        }

        public Algorithm ShowChooseAlgorithmDialog(IEnumerable<Algorithm> algorithms)
        {
            using (var dialog = new ChooseAlgorithmDialog(algorithms))
            {
                dialog.Owner = Application.Current.MainWindow;
                dialog.ShowDialog();
                return dialog.SelectedAlgorithm;
            }
        }

        public DeviceEntry ShowChooseDeviceDialog(IDevicesFactory devicesFactory)
        {
            using (var dialog = new ChooseDeviceDialog(devicesFactory))
            {
                dialog.Owner = Application.Current.MainWindow;
                dialog.ShowDialog();
                return dialog.SelectedDevice;
            }
        }

        public void ShowErrorMessage(Exception error, string caption = null)
        {
            var msg = error.Message;
            if (!string.IsNullOrEmpty(error.InnerException?.Message))
            {
                msg += "\r\n" + error.InnerException?.Message;
            }

            service.Show(msg, caption ?? "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void ShowErrorMessage(string error, string caption = null)
        {
            service.Show(error, caption ?? "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public bool ShowExamineResultDialog(int value)
        {
            using (var dialog = new CheckResultsDialog(value))
            {
                dialog.Owner = Application.Current.MainWindow;
                dialog.ShowDialog();
                return ((CheckResultsDialogViewModel) dialog.DataContext).IsRetry;
            }
        }

        public void ShowInfoDialog()
        {
            using (var infoDialog = new InfoDialog())
            {
                infoDialog.Owner = Application.Current.MainWindow;
                infoDialog.ShowDialog();
            }
        }

        public void ShowInfoMessage(string text, string caption = null)
        {
            service.Show(text, caption ?? "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public bool ShowLoginDialog()
        {
            using (var loginDialog = new LoginDialog(this))
            {
                loginDialog.Owner = Application.Current.MainWindow;
                var result = loginDialog.ShowDialog();
                return result.HasValue && result.Value;
            }
        }

        public async Task<bool> ShowRegisterDialogAsync()
        {
            using (var registerDialog = new RegisterDialog(this))
            {
                registerDialog.Owner = Application.Current.MainWindow;
                await registerDialog.Initialize();
                var result = registerDialog.ShowDialog();
                return result.HasValue && result.Value;
            }
        }

        public TrainingCompleteDialogResult ShowTrainingCompleteDialog()
        {
            using (var dialog = new TrainingCompleteDialog())
            {
                dialog.Owner = Application.Current.MainWindow;
                dialog.ShowDialog();
                return new TrainingCompleteDialogResult
                       {
                           GoExamine = dialog.GoExamine,
                           GoRetry = dialog.GoRetry
                       };
            }
        }

        public void ShowWarningMessage(string text, string caption = null)
        {
            service.Show(text, caption ?? "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        #endregion
    }
}