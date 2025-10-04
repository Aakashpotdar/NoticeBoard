using Manager.Interface;
using NoticeBoardApp.Models;
using Repository.Interface;
using System.Threading.Tasks;

namespace Manager.Manager
{
    public class NoteManager:INoteManager
    {
        private readonly INoteRepository noteRepo;

        public NoteManager(INoteRepository noteRepo)
        {
            this.noteRepo = noteRepo;           
        }

        public async Task<bool> addNote(NoteModel note)
        {
            return await this.noteRepo.addNote(note);
        }

        public async Task<bool> deleteNote(NoteModel note)
        {
            return await this.noteRepo.deleteNote(note);
        }

        public async Task<bool> editNote(NoteModel note)
        {
            return await this.noteRepo.editNote(note);
        }
    }
}
