﻿using Pithline.FMS.ServiceScheduling.UILogic.Services;
using Pithline.WinRT.Components.Controls;
using Microsoft.Practices.Prism.StoreApps;
using Microsoft.Practices.Prism.StoreApps.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pithline.FMS.ServiceScheduling.UILogic.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        private IAccountService _accountService;
        public LoginPageViewModel(INavigationService navigationService, IAccountService accountService) :base (navigationService)
        {
            _navigationService = navigationService;
            _accountService = accountService;
            ProgressDialogPopup = new ProgressDialog();
            LoginCommand = DelegateCommand.FromAsyncHandler(
                async () =>
                {
                    try
                    {
                        ProgressDialogPopup.Open(this);
                        IsLoggingIn = true;
                        var result = await _accountService.SignInAsync(this.UserName, this.Password, this.ShouldSaveCredential);
                        if (result.Item1 != null)
                        {
                            string jsonUserInfo = JsonConvert.SerializeObject(result.Item1);
                            navigationService.Navigate("Main", jsonUserInfo);
                        }
                        else
                        {
                            ProgressDialogPopup.Close();
                            ErrorMessage = result.Item2;
                        }

                    }
                    catch (Exception ex)
                    {
                        AppSettings.Instance.ErrorMessage = ex.Message;
                    }
                    finally
                    {
                        ProgressDialogPopup.Close();
                        IsLoggingIn = false;
                    }
                },

                 () => { return !string.IsNullOrEmpty(this.username) && !string.IsNullOrEmpty(this.password); });

        }
        public DelegateCommand LoginCommand { get; private set; }

        private string username;
        [RestorableState]
        public string UserName
        {
            get { return username; }
            set
            {
                if (SetProperty(ref username, value))
                    LoginCommand.RaiseCanExecuteChanged();
            }
        }
        private ProgressDialog progressDialogPopup;

        public ProgressDialog ProgressDialogPopup
        {
            get { return progressDialogPopup; }
            set { SetProperty(ref progressDialogPopup, value); }
        }

        private string password;
        [RestorableState]
        public string Password
        {
            get { return password; }
            set
            {
                if (SetProperty(ref password, value))
                    LoginCommand.RaiseCanExecuteChanged();
            }
        }

        private bool shouldSaveCredential;
        [RestorableState]
        public bool ShouldSaveCredential
        {
            get { return shouldSaveCredential; }
            set { SetProperty(ref shouldSaveCredential, value); }
        }

        private string errorMessage;
        [RestorableState]
        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        private bool isLoggingIn;
        public bool IsLoggingIn
        {
            get { return isLoggingIn; }
            set { SetProperty(ref isLoggingIn, value); }
        }

    }
}
