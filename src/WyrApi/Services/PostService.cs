using MongoDB.Driver;
using WyrApi.Models;

namespace WyrApi.Services;
public class PostService
{
  public static readonly FilterDefinitionBuilder<Post> Filter = Builders<Post>.Filter;
  public static readonly UpdateDefinitionBuilder<Post> Update = Builders<Post>.Update;
  public static readonly SortDefinitionBuilder<Post> Sort = Builders<Post>.Sort;
  public static readonly FindOneAndUpdateOptions<Post> _ReturnAfter = new() { ReturnDocument = ReturnDocument.After };
  public IMongoCollection<Post> Collection { get; init; }

  public PostService(IMongoCollection<Post> collection)
  {
    Collection = collection;
  }

  public Task<List<Post>> ListAsync()
  {
    return Collection.Find(Filter.Empty).ToListAsync();

  }

  public Task<Post> GetByIdAsync(string id)
  {
    return Collection.Find(Filter.Eq(p => p.Id, id)).FirstOrDefaultAsync();
  }

  public Task CreateAsync(Post post)
  {
    return Collection.InsertOneAsync(post);
  }

  public Task<Post> UpdateAsync(string id, Post post)
  {
    var filter = Filter.Eq(p => p.Id, id);
    var update = Update
        .Set(p => p.FirstChoice, post.FirstChoice)
        .Set(p => p.SecondChoice, post.SecondChoice)
        .Set(p => p.Pending, post.Pending)
        .CurrentDate(p => p.UpdatedAt);

    return Collection.FindOneAndUpdateAsync(filter, update, _ReturnAfter);
  }


  public Task<Post> GetByIdExceptIdsAsync(List<string> ids)
  {
    var filter = Filter.Where(r => !ids.Contains(r.Id));

    return Collection.Find(filter).FirstOrDefaultAsync();
  }
}
