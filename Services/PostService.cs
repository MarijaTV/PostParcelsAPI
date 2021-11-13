using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PostParcelsAPI.Dtos;
using PostParcelsAPI.Models;
using PostParcelsAPI.Repositories;

namespace PostParcelsAPI.Services
{
    public class PostService
    {
        private readonly PostRepository _postRepository;
        private readonly ParcelRepository _parcelRepository;
        private readonly IMapper _mapper;

        public PostService(PostRepository postRepository, ParcelRepository parcelRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _parcelRepository = parcelRepository;
            _mapper = mapper;
        }

        public async Task<List<Post>> GetAllAsync() => await _postRepository.GetAllAsync();
        public async Task<Post> GetByIdAsync(int id)
        {
            var post = await _postRepository.GetById(id);
            if (post == null)
            {
                throw new ArgumentException("Records not found");
            }
            return post;
        }
        public async Task<List<Post>> GetFreePostsAsync()
        {
            var posts = await _postRepository.GetAllAsync();

            foreach (var freePost in posts)
            {
                freePost.Capacity = await _parcelRepository.PostCapacity(freePost.Id);
            }

            return posts;
        }
        public async Task DeleteAsync(int id)
        {
            var post = await GetByIdAsync(id);
            if (post == null)
            {
                throw new ArgumentException("Records not found");
            }
            await _postRepository.DeleteAsync(post);
        }
        public async Task<Post> CreateAsync(CreatePostDto postDto)
        {
            var entity = _mapper.Map<Post>(postDto);
            await _postRepository.CreateAsync(entity);
            return entity;
        }
        public async Task UpdateAsync(int id, Post post)
        {
            var entity = await _postRepository.GetById(id);
            if (entity == null)
            {
                throw new ArgumentException("Records not found");
            }
            entity.Id = post.Id;
            entity.City = post.City;
            entity.Code = post.Code;
            entity.Capacity = post.Capacity;

            await _postRepository.UpdateAsync(entity);
        }
    }
}
