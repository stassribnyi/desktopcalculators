using System;
using System.Linq;
using DAL.EntityModel;
using DAL.Repository;
using DAL.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Octagon.DataModels;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Octagon.Client.ViewModels
{
    public class SelectUserViewModel : ViewModelBase
    {
        private IList<UserNameModel> _userNameList;

        private string _newUser;

        private ICommand _selectUserCommand;
        private ICommand _createUserCommand;

        public event EventHandler<SelectUserEventArgs> RaiseSelectUserEvent;

        public IList<UserNameModel> UserList
        {
            get { return _userNameList; }
            set
            {
                _userNameList = value;
                RaisePropertyChanged(() => UserList);
            }
        }

        public string NewUser
        {
            get { return _newUser; }
            set
            {
                _newUser = value;
                RaisePropertyChanged(()=>NewUser);
            }
        }

        public SelectUserViewModel()
        {
            InitName(new UserNameRepository());
        }

        private void InitName(IRepository<UserNameModel> context)
        {
            UserList = context.Select();
        }

        private void CreateUser(IServises<UserMemoryModel, UserHistoryModel, UserNameModel> context)
        {
            if (NewUser != "")
            {
                //костыль
                var memContext = new UserMemoryRepository();
                var lastUser = memContext.Select().Select(i=>i.UserId).Last();

                var user = new UserMemoryModel();
                var history = new UserHistoryModel();
                var name = new UserNameModel{UserId = lastUser+1, Name = NewUser};

                context.Create(user, history, name);
                NewUser = "";
            }
        }

        public ICommand SelectUserCommand
        {
            get
            {
                return _selectUserCommand ??
                       (_selectUserCommand = new RelayCommand(() => OnRaiseSelectUserEvent(new SelectUserEventArgs(1))));
            }
        }

        public ICommand CreateUserCommand
        {
            get
            {
                return _createUserCommand ?? (_createUserCommand = new RelayCommand(() =>
                {
                    CreateUser(new UserDataService());
                    InitName(new UserNameRepository());
                    OnRaiseSelectUserEvent(new SelectUserEventArgs(_userNameList.Last().UserId + 1)); 
                }
                    ));
            }
        }

        protected virtual void OnRaiseSelectUserEvent(SelectUserEventArgs eventArgs)
        {
            EventHandler<SelectUserEventArgs> handler = RaiseSelectUserEvent;
            if (handler != null)
            {
                handler(this, eventArgs);
            }
        }

    }
}
