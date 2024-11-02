﻿using CafeApp.Shared.RestClient.Interfaces;
using System.Net.Http.Json;

namespace CafeApp.Shared.RestClient.Repositories
{
    internal class BaseClient<TEntity> : IBaseClient<TEntity>
    {
        protected readonly HttpClient _httpClient;
        protected readonly string _api;

        public BaseClient(HttpClient httpClient, string api)
        {
            _httpClient = httpClient;
            _api = api;
        }

        public async Task Apply()
        {
           await _httpClient.GetAsync($"{_api}/sync");
        }

        public async Task<ICollection<TEntity>> SyncCategories()
        {
            var res = await _httpClient.GetFromJsonAsync<ICollection<TEntity>>($"{_api}/sync");
            return res!;
        }

        public async Task WriteSync(TEntity entity)
        {
            await _httpClient.PostAsJsonAsync($"{_api}/writesync",entity);
        }
    }
}
