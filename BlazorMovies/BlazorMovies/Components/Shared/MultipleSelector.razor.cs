﻿using BlazorMovies.Components.Helpers;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace BlazorMovies.Components.Shared
{
    public partial class MultipleSelector
    {
        private readonly string removeAllText = "<<";

        private void SelectItem(MultipleSelectorModel item)
        {
            NotSelected.Remove(item);
            Selected.Add(item);
        }

        private void DeSelectItem(MultipleSelectorModel item)
        {
            Selected.Remove(item);
            NotSelected.Add(item);
        }

        private void SelectAllItems()
        {
            Selected.AddRange(NotSelected);
            NotSelected.Clear();
        }

        private void DeselectAllItems()
        {
            NotSelected.AddRange(Selected);
            Selected.Clear();
        }

        [Parameter]
        public List<MultipleSelectorModel> NotSelected { get; set; } = new List<MultipleSelectorModel>();

        [Parameter]
        public List<MultipleSelectorModel> Selected { get; set; } = new List<MultipleSelectorModel>();
    }
}