using Model.Exceptions;
using Manager.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Model;
using NoticeBoardApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoticeBoardApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly INoteManager noteManager;


        public NoteController(INoteManager note)
        {
            noteManager = note;
        }

        [HttpPost]
        [Route("addNote")]
        public async Task<IActionResult> addNote([FromBody] NoteModel note)
        {
            try
            {
                if (note != null)
                {
                    var output = await noteManager.addNote(note);
                    return this.Ok(new { Status = true, Massage = "note successfully added" });
                }
                else
                {
                    return this.BadRequest(new { Status = true, Massage = "Give invalid inputs" });
                }
            }
            catch (BadRequestException ex)
            {
                throw new BadRequestException(400, "INVALID_INPUT");
            }
        }

        [HttpDelete]
        [Route("deleteNote")]
        public async Task<IActionResult> deleteNote([FromBody] NoteModel note)
        {
            if (note.noteId != null)
            {
                var output = await noteManager.deleteNote(note);
                return this.Ok(new { Status = true, Massage = "note successfully deleted" });

            }
            return this.BadRequest(new { Status = true, Massage = "Give invalid inputs" });

        }

        [HttpPut]
        [Route("editNote")]
        public async Task<IActionResult> editNote([FromBody]NoteModel note)
        {
            if (note != null)
            {
                var output = await noteManager.editNote(note);
                return this.Ok(new { Status = true, Massage = "note successfully edited" });

            }
            return this.BadRequest(new { Status = true, Massage = "Give invalid inputs" });
        }
    }
}
