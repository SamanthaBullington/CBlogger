using System;
using System.Collections.Generic;
using CBlogger.Repositories;
using CBlogger.Models;

namespace CBlogger.Services
{
  public class BlogsService
  {
    private readonly BlogsRepository _repo;

    public BlogsService(BlogsRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Blog> Get()
    {
      return _repo.Get();
    }

    internal Blog Get(int id)
    {
      Blog blog = _repo.Get(id);
      if (blog == null)
      {
        throw new Exception("Invalid Id");
      }
      return blog;
    }

    internal Blog Create(Blog newBlog)
    {
      Blog blog = _repo.Create(newBlog);
      if (blog == null)
      {
        throw new Exception("Invalid Id");
      }
      return blog;
    }

    internal Blog Edit(Blog updatedBlog)
    {
      // Find the original before edits
      Blog original = Get(updatedBlog.Id);
      // check each value on the incoming object, if it exits then allow it to continue, if it does not set it to the original value
      updatedBlog.Title = updatedBlog.Title != null ? updatedBlog.Title : original.Title;
      updatedBlog.Body = updatedBlog.Body != null ? updatedBlog.Body : original.Body;
      updatedBlog.imgUrl = updatedBlog.imgUrl != null ? updatedBlog.imgUrl : original.imgUrl;
      return _repo.Update(updatedBlog);
    }

    internal void Delete(int id)
    {
      Blog original = Get(id);
      _repo.Delete(id);
    }
  }
}