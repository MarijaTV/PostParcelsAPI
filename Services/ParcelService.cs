using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PostParcelsAPI.Dtos;
using PostParcelsAPI.Models;
using PostParcelsAPI.Repositories;

namespace PostParcelsAPI.Services
{
    public class ParcelService
    {
        private readonly PostRepository _postRepository;
        private readonly ParcelRepository _parcelRepository;
        private readonly IMapper _mapper;

        public ParcelService(PostRepository postRepository, ParcelRepository parcelRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _parcelRepository = parcelRepository;
            _mapper = mapper;
        }
        public async Task<List<Parcel>> GetAllAsync() => await _parcelRepository.GetAllAsync();
        public async Task<Parcel> GetByIdAsync(int id)
        {
            var post = await _parcelRepository.GetById(id);
            if (post == null)
            {
                throw new ArgumentException("Records not found");
            }
            return post;
        }
        public async Task DeleteAsync(int id)
        {
            var parcel = await GetByIdAsync(id);
            if (parcel == null)
            {
                throw new ArgumentException("Records not found");
            }
            await _parcelRepository.DeleteAsync(parcel);
        }
        public async Task<Parcel> CreateAsync(CreateParcelDto parcelDto)
        {
            var entity = _mapper.Map<Parcel>(parcelDto);
            await _parcelRepository.CreateAsync(entity);
            return entity;

        }
        public async Task<UpdateParcelDto> UpdateAsync(UpdateParcelDto updatedParcel)
        {
            var doesExist = await _parcelRepository.DoesExistAsync(updatedParcel.Id);
            if (!doesExist)
            {
                throw new ArgumentException($"Id {updatedParcel.Id} does not exist.");
            }
            var parcelToUpdated = _mapper.Map<Parcel>(updatedParcel);
            await _parcelRepository.UpdateAsync(parcelToUpdated);
            Post post = await _postRepository.GetById((int)updatedParcel.PostId); //reikia tikrinimo ar ne pilnas
            UpdateParcelDto parcelDto = new()
            {
                Id = updatedParcel.Id,
                Weight = updatedParcel.Weight,
                Phone = updatedParcel.Phone,
                Text = updatedParcel.Text,
                PostId = updatedParcel.PostId,
                PostCode = post.Code
            };
            return parcelDto;
        }
        public async Task<List<Parcel>> GetByPostIdAsync(int postId)
        {
            var parcels = await _parcelRepository.GetAllAsync();
            if (postId != 0)
            {
                return await _parcelRepository.GetByPostIdAsync(postId);
            }
            return parcels;
        }

    }
}
