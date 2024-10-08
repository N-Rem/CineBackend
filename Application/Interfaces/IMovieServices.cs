﻿using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMovieServices
    {
        MovieDto GetMovieById(int id);
        List<Movie> GetAll();
        void Create(MovieCreateRequest movieDto);
        void UpdateMovie (MovieUpdateRequest movieDto, int id);
        void Delete(int id);
    }
}
