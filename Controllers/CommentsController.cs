using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CBlogger.Models;
using CBlogger.Services;


namespace CBlogger.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class CommentsController : ControllerBase
  {
    private readonly CommentsService _commentsService;

    public CommentsController(CommentsService commentsService)
    {
      _commentsService = commentsService;
    }

    // GETALL
    [HttpGet]
    public ActionResult<IEnumerable<Comment>> Get()
    {
      try
      {
        IEnumerable<Comment> comments = _commentsService.Get();
        return Ok(comments);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    // GetById
    [HttpGet("{id}")]
    public ActionResult<Comment> Get(int id)
    {
      try
      {
        Comment comment = _commentsService.Get(id);
        return Ok(comment);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    // Create
    [HttpPost]
    public ActionResult<Comment> Create([FromBody] Comment newComment)
    {
      try
      {
        Comment comment = _commentsService.Create(newComment);
        return Ok(comment);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    // Update
    [HttpPut("{id}")]
    public ActionResult<Comment> Edit([FromBody] Comment updatedComment, int id)
    {
      try
      {
        updatedComment.Id = id;
        Comment comment = _commentsService.Edit(updatedComment);
        return Ok(comment);
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
        _commentsService.Delete(id);
        return Ok("Successfully Deleted");
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

  }
}