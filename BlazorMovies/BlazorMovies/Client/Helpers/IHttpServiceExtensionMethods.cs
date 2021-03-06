﻿using BlazorMovies.Shared.DataTransferObjects;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Helpers
{
    public static class IHttpServiceExtensionMethods
    {
        public static async Task<T> GetHelper<T>(this IHttpService httpService, string url, bool includeToken = true)
        {
            var response = await httpService.Get<T>(url, includeToken);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }

        public static async Task<PaginatedResponse<T>> GetHelper<T>(this IHttpService httpService, string url, PaginationDTO paginationSettings, bool includeToken = true)
        {
            string newURL;
            if (url.Contains("?"))
            {
                newURL = $"{url}&page={paginationSettings.Page}&recordsPerPage={paginationSettings.RecordsPerPage}";
            }
            else
            {
                newURL = $"{url}?page={paginationSettings.Page}&recordsPerPage={paginationSettings.RecordsPerPage}";
            }

            var httpResponse = await httpService.Get<T>(newURL, includeToken);
            var totalAmountOfPages = int.Parse(httpResponse.HttpResponseMessage.Headers.GetValues("totalAmountOfPages").FirstOrDefault());

            var paginatedResponse = new PaginatedResponse<T>
            {
                Response = httpResponse.Response,
                TotalAmountOfPages = totalAmountOfPages
            };

            return paginatedResponse;
        }
    }
}
