using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using CBlogger.Models;

namespace CBlogger.Repositories
{
  public class BlogsRepository
  {
    private readonly IDbConnection _db;

    public BlogsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Blog> Get()
    {
      string sql = "SELECT * FROM blogs";
      return _db.Query<Blog>(sql).ToList();
    }

    internal Blog Get(int id)
    {
      // the '@' is used by dapper to pull in variables off of a provided object
      string sql = "SELECT * FROM blogs WHERE id = @id";
      //   Query first or default retruns a single objecr or NULL if not found
      return _db.QueryFirstOrDefault<Blog>(sql, new { id });
    }

    internal Blog Create(Blog newBlog)
    {
      string sql = @"
      INSERT INTO blogs
      (title, body, imgUrl, published, creatorId)
      VALUES
      (@Title, @Body, @ImgUrl, @Published, @CreatorId);
      SELECT LAST_INSERT_ID();";
      newBlog.Id = _db.ExecuteScalar<int>(sql, newBlog);
      return newBlog;
    }

    internal Blog Update(Blog updatedBlog)
    {
      string sql = @"
        UPDATE blogs
        SET
            title = @Title,
            body = @Body,
            imgUrl = @ImgUrl
        WHERE id = @Id;
      ";
      _db.Execute(sql, updatedBlog);
      return updatedBlog;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM blogs WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}