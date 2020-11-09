using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Movies.Api.Dto;
using Movies.BusinessLogic.Repository;
using Movies.BusinessLogic.ServicesInterface;
using Movies.EFDataAccess;
using Movies.EFDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.BusinessLogic.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly MoviesContext _context;
        private readonly IMapper _mapper;

        public MoviesService(MoviesContext context, IMapper mapper)
        : base(context)
        {
            this._context = context;
            _mapper = mapper;
        }

        public async Task<MovieDto> GetMovieByID(int id)
        {
            try
            {
                var result = await FindSingle(id);
                if (result == null)
                {
                    return null;
                }

                return _mapper.Map<MovieDto>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<MovieDto>> GetAllMovies()
        {
            try
            {
                var result = await LoadAll();
                if (result == null)
                {
                    return null;
                }

                return _mapper.Map<List<MovieDto>>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> CountMovies()
        {
            return await _context.Set<Movie>().CountAsync();
        }

        public async Task AddMovie(MovieDto movieDto)
        {
            var record = _mapper.Map<Movie>(movieDto);
            Add(record);
            await Commit();
        }

        public async Task DeleteMovie(int Id)
        {
            DeleteWhere(c => c.Id == Id);
            await Commit();
        }

        public async Task UpdateMovie(MovieDto movieDto)
        {
            var record = _mapper.Map<Movie>(movieDto);
            Update(record);
            await Commit();
        }
    }
}
