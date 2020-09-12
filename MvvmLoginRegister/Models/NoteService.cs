using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLoginRegister.Models
{
    public class NoteService
    {
        int uId, objCount;
        MvvmDemoDbEntities ObjContext;

        public NoteService(int id)
        {
            ObjContext = new MvvmDemoDbEntities();
            this.uId = id;
        }

        public ObservableCollection<NoteDTO> GetAll(int skip, int take, string srch)
        {
            ObservableCollection<NoteDTO> ObjNoteList = new ObservableCollection<NoteDTO>();
            try
            {
                var ObjQuery = (from note in ObjContext.Notes
                                where note.UserId == uId && note.NoteData.Contains(srch)
                                orderby note.Id
                                select note).Skip(skip).Take(take);
                foreach (var note in ObjQuery)
                {

                    ObjNoteList.Add(new NoteDTO(note.UserId, note.NoteData, note.Id, note.CreateTime));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjNoteList;

        }

        public int GetObjCount(string srch)
        {
            objCount = (from note in ObjContext.Notes where note.UserId == uId && note.NoteData.Contains(srch) select note).Count();
            return objCount;
        }

        public bool Add(NoteDTO objNewNote)
        {
            bool IsAdded = false;
            try
            {
                var ObjNote = new Note();
                ObjNote.UserId = objNewNote.UserId;
                ObjNote.NoteData = objNewNote.UserNotes;
                ObjNote.CreateTime = DateTime.Now;
                ObjContext.Notes.Add(ObjNote);
                var NoOfRowsAffected = ObjContext.SaveChanges();
                IsAdded = NoOfRowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return IsAdded;
        }
    }
}
