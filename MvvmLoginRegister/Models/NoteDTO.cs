using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLoginRegister.Models
{
    public class NoteDTO : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public NoteDTO() { }
        public NoteDTO(int Userid, string nt, int id, DateTime? dt)
        {
            this.userId = Userid;
            this.userNotes = nt;
            this.noteId = id;
            this.noteTime = dt;
        }

        private int userId;
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private string userNotes;
        public string UserNotes
        {
            get { return userNotes; }
            set { userNotes = value; OnPropertyChanged("UserNotes"); }
        }

        private int noteId;
        public int NoteId
        {
            get { return noteId; }
            set { noteId = value; }
        }

        private DateTime? noteTime;
        public DateTime? NoteTime
        {
            get { return noteTime; }
            set { noteTime = value; }
        }
    }
}
