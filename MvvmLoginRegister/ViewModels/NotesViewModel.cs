using MvvmLoginRegister.Commands;
using MvvmLoginRegister.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmLoginRegister.ViewModels
{
    public class NotesViewModel : BaseViewModel
    {

        NoteService ObjNoteService;
        public NotesViewModel(UserDTO curr)
        {
            ObjNoteService = new NoteService(curr.Id);
            LoadData(0, 5, SearchStr);
            CurrentNote = new NoteDTO();
            saveCommand = new RelayCommand(Save);
            CurrentUser = curr;

            PageInfo = new PageModel(0, 5);
            PageInfo.TotalPageNo = (int)Math.Ceiling(((double)ObjNoteService.GetObjCount(SearchStr) / (double)PageInfo.Take));
            previousPageC = new RelayCommand(previousPage);
            nextPageC = new RelayCommand(nextPage);
            searchCommand = new RelayCommand(searchString);

            PageInfo.CurrentPageNo = 1;
        }

        private ObservableCollection<NoteDTO> notesList;
        public ObservableCollection<NoteDTO> NotesList
        {
            get { return notesList; }
            set { notesList = value; OnPropertyChanged("NotesList"); }
        }

        private void LoadData(int skip, int take, string srch)
        {
            NotesList = ObjNoteService.GetAll(skip, take, srch);
            Console.WriteLine("cccc");
        }

        public void searchString()
        {
            PageInfo.Skip = 0;
            PageInfo.CurrentPageNo = 1;
            LoadData(PageInfo.Skip, PageInfo.Take, SearchStr);
            PageInfo.TotalPageNo = (int)Math.Ceiling((ObjNoteService.GetObjCount(SearchStr) / PageInfo.Take) + 0.5);

        }

        private NoteDTO currentNote;
        public NoteDTO CurrentNote
        {
            get { return currentNote; }
            set { currentNote = value; OnPropertyChanged("CurrentNote"); }
        }

        private UserDTO currentUser;
        public UserDTO CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; OnPropertyChanged("CurrentUser"); }
        }

        private PageModel pageInfo;
        public PageModel PageInfo
        {
            get { return pageInfo; }
            set { pageInfo = value; OnPropertyChanged("PageInfo"); }
        }

        private string searchStr = "";

        public string SearchStr
        {
            get { return searchStr; }
            set { searchStr = value; OnPropertyChanged("SearchStr"); }
        }

        private RelayCommand searchCommand;
        public RelayCommand SearchCommand
        {
            get { return searchCommand; }
        }

        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
        }

        private RelayCommand nextPageC;
        public RelayCommand NextPageC
        {
            get { return nextPageC; }
        }

        private RelayCommand previousPageC;
        public RelayCommand PreviousPageC
        {
            get { return previousPageC; }
        }

        public void nextPage()
        {
            PageInfo.Skip += 5;

            if (PageInfo.Skip > ObjNoteService.GetObjCount(SearchStr))
            {
                PageInfo.Skip -= 5;
                PageInfo.CurrentPageNo--;
            }
            LoadData(PageInfo.Skip, PageInfo.Take, SearchStr);
            PageInfo.CurrentPageNo += 1;
        }

        public void previousPage()
        {
            PageInfo.Skip -= 5;
            if (PageInfo.Skip < 0)
            {
                PageInfo.Skip = 0;
                return;
            }
            LoadData(PageInfo.Skip, PageInfo.Take, SearchStr);
            PageInfo.CurrentPageNo -= 1;
        }

        public void Save()
        {
            CurrentNote.UserId = CurrentUser.Id;
            var IsSaved = ObjNoteService.Add(CurrentNote);
            LoadData(PageInfo.Skip, PageInfo.Take, SearchStr);
            CurrentNote = new NoteDTO();
            PageInfo.TotalPageNo = (int)Math.Ceiling((ObjNoteService.GetObjCount(SearchStr) / PageInfo.Take) + 0.5);
        }
    }
}
