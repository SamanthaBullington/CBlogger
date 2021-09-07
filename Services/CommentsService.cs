using System;
using System.Collections.Generic;
using CBlogger.Repositories;
using CBlogger.Models;

namespace CBlogger.Services
{
  public class CommentsService
  {
    private readonly CommentsRepository _repo;

    public CommentsService(CommentsRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Comment> Get()
    {
      return _repo.Get();
    }

    internal Comment Get(int id)
    {
      Comment comment = _repo.Get(id);
      if (comment == null)
      {
        throw new Exception("Invalid Id");
      }
      return comment;
    }

    internal Comment Create(Comment newComment)
    {
      Comment comment = _repo.Create(newComment);
      if (comment == null)
      {
        throw new Exception("Invalid Id");
      }
      return comment;
    }

    internal Comment Edit(Comment updatedcomment)
    {
      // Find the original before edits
      Comment original = Get(updatedcomment.Id);
      // check each value on the incoming object, if it exits then allow it to continue, if it does not set it to the original value
      updatedcomment.Body = updatedcomment.Body != null ? updatedcomment.Body : original.Body;
      return _repo.Update(updatedcomment);
    }

    internal void Delete(int id)
    {
      Comment original = Get(id);
      _repo.Delete(id);
    }
  }
}