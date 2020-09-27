﻿using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoviesAPI.DTOs;
using MoviesAPI.Entities;
using MoviesAPI.Filters;
using MoviesAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Controllers
{
    [Route("api/genres")]
    [ApiController]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GenresController : CustomBaseController
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GenresController(
            ApplicationDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet(Name = "getGenres")]   //  api/genres
        [EnableCors(PolicyName = "AllowAPIRequestIO")]
        public async Task<ActionResult<List<GenreDTO>>> Get()
        {
            return await Get<Genre, GenreDTO>();
        }

        [HttpGet("{Id:int}", Name = "getGenre")]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(GenreDTO), 200)]
        public async Task<ActionResult<GenreDTO>> Get(int Id)
        {
            return await Get<Genre, GenreDTO>(Id);
        }

        [HttpPost(Name = "createGenre")]
        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult> Post([FromBody] GenreCreationDTO genreCreation)
        {
            return await Post<GenreCreationDTO, Genre, GenreDTO>(genreCreation, "getGenre");
        }

        [HttpPut("{id}", Name = "putGenre")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult> Put(int id, [FromBody] GenreCreationDTO genreCreation)
        {
            return await Put<GenreCreationDTO, Genre>(id, genreCreation);
        }

        /// <summary>
        /// Delete a genre
        /// </summary>
        /// <param name="id">id of the genre to delete</param>
        /// <returns></returns>
        [HttpDelete("{id}", Name = "deleteGenre")]
        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            return await Delete<Genre>(id);
        }
    }
}
