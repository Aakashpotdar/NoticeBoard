using NoticeBoardApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface INoteRepository
    {
        public Task<bool> addNote(NoteModel noteModel);
        public Task<bool> deleteNote(NoteModel noteModel);
        public Task<bool> editNote(NoteModel noteModel);
    }
}
