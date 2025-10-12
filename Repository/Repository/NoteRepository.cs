using Microsoft.Extensions.Configuration;
using Model.Interface;
using MongoDB.Driver;
using NoticeBoardApp.Models;
using Repository.Interface;
using System;
using Model.Exceptions;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class NoteRepository : INoteRepository
    {
        public readonly IMongoCollection<NoteModel> collection;

        public readonly IConfiguration configuration;

        public NoteRepository(INoticeBoardDBConnection dbConnection, IConfiguration config)
        {
            this.configuration = config;
            var client = new MongoClient(dbConnection.ConnectionString);
            var mongoDb = client.GetDatabase(dbConnection.dbName);

            this.collection = mongoDb.GetCollection<NoteModel>("Notes");
        }

        public async Task<bool> addNote(NoteModel noteModel)
        {
            try
            {
                if (noteModel.userId != null)
                {
                    await this.collection.InsertOneAsync(noteModel);
                    return true;
                }
                return false;
            }
            catch(ServerException e)
            {
                throw new ServerException(404,"SERVER_NOT_FOUND");
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> deleteNote(NoteModel noteModel)
        {
            try
            {
                if (noteModel.userInfo!=null)
                {
                    var info = await this.collection.FindAsync(a => a.noteId == noteModel.noteId);
                    if (info != null)
                    {
                        await this.collection.DeleteOneAsync(de => de.noteId == noteModel.noteId);
                        return true;
                    }
                    return false;
                }
                return false;
            }
            catch (ServerException e)
            {
                throw new ServerException(404, "SERVER_NOT_FOUND");
            }
            catch (Exception ex)
            {
                throw new Exception(message: ex.Message);
            }
        }

        public async Task<bool> editNote(NoteModel noteModel)
        {
            try
            {
                if (noteModel.noteId != null)
                {
                    var info = await this.collection.FindAsync(fi => fi.noteId == noteModel.noteId);
                    if (info != null)
                    {
                        await this.collection.FindOneAndReplaceAsync(re => re.noteId == noteModel.noteId,noteModel);
                    }
                    return false;
                }
                return false;
            }
            catch (ServerException e)
            {
                throw new ServerException(404, "SERVER_NOT_FOUND");
            }
            catch (Exception ex)
            {
                throw new Exception(message: ex.Message);
            }
        }
    }
}
