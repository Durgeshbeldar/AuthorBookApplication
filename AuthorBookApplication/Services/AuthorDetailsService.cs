using AuthorBookApplication.DTOs;
using AuthorBookApplication.Exceptions;
using AuthorBookApplication.Models;
using AuthorBookApplication.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuthorBookApplication.Services
{
    public class AuthorDetailsService : IAuthorDetailsService
    {
        private readonly IRepository<AuthorDetails> _authorDetailsRepository;
        private readonly IMapper _mapper;

        public AuthorDetailsService(IRepository<AuthorDetails> authorDetailsRepository, IMapper mapper)
        {
            _authorDetailsRepository = authorDetailsRepository;
            _mapper = mapper;
        }

        public int AddAuthorDetails(AuthorDetailsDto authorDetailsDto)
        {
            var authorDetails = _mapper.Map<AuthorDetails>(authorDetailsDto);
            _authorDetailsRepository.Add(authorDetails);
            return authorDetails.Id;
        }

        public bool DeleteAuthorDetails(int id)
        {
            var authorDetails = _authorDetailsRepository.GetById(id);
            if (authorDetails != null)
            {
                _authorDetailsRepository.Delete(authorDetails);
                return true;
            }
            throw new AuthorDetailsNotFoundException($"Author Details Not Found with Given Id : {id}");
        }

        public AuthorDetailsDto GetAuthorDetail(int id)
        {
            var authorDetail =  _authorDetailsRepository.GetAll().Include(ad => ad.Author).FirstOrDefault(ad => ad.Id == id);
            if (authorDetail == null)
                throw new AuthorDetailsNotFoundException($"Author Details Not Found with Given Id : {id}");
            var authorDetailDto = _mapper.Map<AuthorDetailsDto>(authorDetail);
            return authorDetailDto;
        }

        public AuthorDetailsDto FindAuthorDetailsByAuthorId(int authorId)
        {
            var authorDetail = _authorDetailsRepository.GetAll().Include(ad => ad.Author).FirstOrDefault(ad => ad.AuthorId == authorId);
            if (authorDetail == null)
                throw new AuthorDetailsNotFoundException($"Author Details Not Found with Given Author Id : {authorId}");
            var authorDetailDto = _mapper.Map<AuthorDetailsDto>(authorDetail);
            return authorDetailDto;
        }
        public List<AuthorDetailsDto> GetAuthorDetails()
        {
            var authorDetails =  _authorDetailsRepository.GetAll().Include(ad=> ad.Author).ToList();
            if (authorDetails == null)
                throw new AuthorDetailsNotFoundException($"Author Details Not Found");
            List<AuthorDetailsDto> authorDetailsDtos = _mapper.Map<List<AuthorDetailsDto>>(authorDetails);
            return authorDetailsDtos;
        }

        public AuthorDetailsDto UpdateAuthorDetails(AuthorDetailsDto authorDetailsDto)
        {
            var authorDetails = _mapper.Map<AuthorDetails>(authorDetailsDto);
            var existingAuthorDetails = _authorDetailsRepository.GetAll().Include(a=> a.Author).AsNoTracking().FirstOrDefault(ad => ad.Id == authorDetails.Id);
            if (existingAuthorDetails != null)
            {
                _authorDetailsRepository.Update(authorDetails);
                return authorDetailsDto;
            }
            throw new AuthorDetailsNotFoundException($"Author Details Not Found with Given Id : {authorDetails.Id}");
        }
    }
}
