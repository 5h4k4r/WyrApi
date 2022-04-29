using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using WyrApi.Services;
using WyrApi.Models;

namespace WyrApi.Controllers;

[Route("v1/posts")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
public class PostsController : ControllerBase
{
  private readonly PostService _postService;

  public PostsController(PostService postService)
  {
    _postService = postService;
  }

  [HttpGet]
  public async Task<IActionResult> ListPosts()
  {
    var posts = await _postService.ListAsync();

    if (posts == null)
      return NotFound();

    return Ok(posts);
  }

  [HttpGet("{id:length(24)}")]
  public async Task<ActionResult<Post>> GetPostById(string id)
  {
    var post = await _postService.GetByIdAsync(id);

    if (post is null)
      return NotFound();

    return post;

  }

  [HttpPost]
  [ProducesResponseType(typeof(Post), StatusCodes.Status200OK)]
  public async Task<IActionResult> CreatePost(CreatePost model)
  {
    var post = model.ToPost();

    await _postService.CreateAsync(post);

    return CreatedAtAction(nameof(CreatePost), post);

  }

  [HttpGet("choices")]
  public async Task<ActionResult<Post>> GetByIdExceptIds([FromQuery] List<string> ids)
  {
    var post = await _postService.GetByIdExceptIdsAsync(ids);

    if (post is null)
      return NotFound();

    return post;

  }
}