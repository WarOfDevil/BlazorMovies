﻿using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Components.Shared
{
    public partial class MultipleSelectorTypeahead<T>
    {
        private T draggedItem;

        private void SelectedElement(T item)
        {
            if (!SelectedElements.Any(x => x.Equals(item)))
            {
                SelectedElements.Add(item);
            }
        }

        private void HandleDragStart(T item)
        {
            draggedItem = item;
        }

        private void HandleDragOver(T item)
        {
            if (!item.Equals(draggedItem))
            {
                var dragElementIndex = SelectedElements.IndexOf(draggedItem);
                var elementIndex = SelectedElements.IndexOf(item);
                SelectedElements[elementIndex] = draggedItem;
                SelectedElements[dragElementIndex] = item;
            }
        }

        [Parameter]
        public List<T> SelectedElements { get; set; } = new List<T>();

        [Parameter]
        public Func<string, Task<IEnumerable<T>>> SearchMethod { get; set; }

        [Parameter]
        public RenderFragment<T> ResultTemplate { get; set; }

        [Parameter]
        public RenderFragment<T> ListTemplate { get; set; }
    }
}
