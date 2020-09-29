﻿using BlazorMovies.Client.Repository;
using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Pages.Movies
{
    public partial class EditMovie
    {
        [Inject]
        public MoviesRepository moviesRepository { get; set; }

        [Inject]
        public NavigationManager navMan { get; set; }

        [Parameter]
        public int MovieId { get; set; }

        private Movie MovieItem;

        private List<Genre> NotSelectedGenre;

        private List<Genre> SelectedGenre;

        private List<BlazorMovies.Shared.Entities.Person> SelectedActors;

        protected async override Task OnInitializedAsync()
        {
            var model = await moviesRepository.GetMovieForUpdateAsync(MovieId);

            MovieItem = model.MovieItem;
            NotSelectedGenre = model.NotSelectedGenres;
            SelectedGenre = model.SelectedGenres;
            SelectedActors = model.Actors;
        }

        private async Task EditMovieItem()
        {
            await moviesRepository.UpdateMovie(MovieItem);
            navMan.NavigateTo($"movie/{MovieId}/{MovieItem.Title.Replace(" ", " - ")}");
        }
    }
}