using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CBlogger.Models;
using CBlogger.Services;


namespace CBlogger.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class BlogsController : ControllerBase
  {
    private readonly BlogsService _blogsService;

    public BlogsController(BlogsService blogsService)
    {
      _blogsService = blogsService;
    }

    // GETALL
    [HttpGet]
    public ActionResult<IEnumerable<Blog>> Get()
    {
      try
      {
        IEnumerable<Blog> blogs = _blogsService.Get();
        return Ok(blogs);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    // GetById
    [HttpGet("{id}")]
    public ActionResult<Blog> Get(int id)
    {
      try
      {
        Blog blog = _blogsService.Get(id);
        return Ok(blog);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    // Create
    [HttpPost]
    public ActionResult<Blog> Create([FromBody] Blog newBlog)
    {
      try
      {
        Blog blog = _blogsService.Create(newBlog);
        return Ok(blog);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    // Update
    [HttpPut("{id}")]
    public ActionResult<Blog> Edit([FromBody] Blog updatedBlog, int id)
    {
      try
      {
        updatedBlog.Id = id;
        Blog blog = _blogsService.Edit(updatedBlog);
        return Ok(blog);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    // Destroy
    [HttpDelete("{id}")]
    public ActionResult<String> Delete(int id)
    {
      try
      {
        _blogsService.Delete(id);
        return Ok("Successfully Deleted");
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

  }
}