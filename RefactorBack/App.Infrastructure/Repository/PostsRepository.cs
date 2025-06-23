using App.Domain.Entities;
using App.Domain.Repository;
using App.Infrastructure.Data;
using App.Infrastructure.Repository.Base;

namespace App.Infrastructure.Repository;

public class PostsRepository(AppDbContext _appDbContext) : 
    RepositoryBase<Posts>(_appDbContext), IPostsRepository;