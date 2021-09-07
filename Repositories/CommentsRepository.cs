using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using CBlogger.Models;

namespace CBlogger.Repositories
{
  public class CommentsRepository
  {
    private readonly IDbConnection _db;

    public CommentsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Comment> Get()
    {
      string sql = "SELECT * FROM comments";
      return _db.Query<Comment>(sql).ToList();
    }

    internal Comment Get(int id)
    {
      // the '@' is used by dapper to pull in variables off of a provided object
      string sql = "SELECT * FROM comments WHERE id = @id";
      //   Query first or default retruns a single objecr or NULL if not found
      return _db.QueryFirstOrDefault<Comment>(sql, new { id });
    }

    internal Comment Create(Comment newComment)
    {
      string sql = @"
      INSERT INTO comments
      (body, creatorId, blog)
      VALUES
      (@Body, @CreatorId, @blog);
      SELECT LAST_INSERT_ID();";
      newComment.Id = _db.ExecuteScalar<int>(sql, newComment);
      return newComment;
    }

    internal Comment Update(Comment updatedComment)
    {
      string sql = @"
        UPDATE comments
        SET
            title = @Title,
            body = @Body,
            imgUrl = @ImgUrl
        WHERE id = @Id;
      ";
      _db.Execute(sql, updatedComment);
      return updatedComment;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM comments WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}