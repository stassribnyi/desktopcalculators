using System;

namespace Octagon.Client.ViewModels
{
    public class SelectUserEventArgs : EventArgs
    {

        private int _id;

        public SelectUserEventArgs(int id)
        {
            _id = id;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
