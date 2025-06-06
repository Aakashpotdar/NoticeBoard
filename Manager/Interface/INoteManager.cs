using NoticeBoardApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Interface
{
    public interface INoteManager
    {
        public Task<bool> addNote(NoteModel note);

        public Task<bool> deleteNote(NoteModel note);

        public Task<bool> editNote(NoteModel note);
    }
}
