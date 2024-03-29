﻿using CarExchange.Core.Models;
using CarExchange.Core.Services.Contracts;
using CarExchange.Infrastructure.Data.Models;
using CarExchange.Infrastructure.Data.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CarExchange.Core.Services
{
    public class ImageService : IImageService
    {

        private readonly IMongoCollection<Image> _images;

        public ImageService(IOptions<MongoDbSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);

            _images = client.GetDatabase(options.Value.DatabaseName)
                .GetCollection<Image>(options.Value.CollectionName);
        }

        public async Task<string> Create(ICollection<string> images)
        {

            var model = new Image();

            foreach (var image in images)
            {

                model.Images.Add(image);
            }

            await _images.InsertOneAsync(model);

            return model.Id;
        }

        public async Task<ImageVM> Get(string id)
        {
            var image = await _images.Find(i => i.Id == id)
                .FirstOrDefaultAsync();

            return new ImageVM { Images = image.Images };
        }

        public async Task<string> GetFirst(string id)
        {
            var image = await _images.Find(i => i.Id == id)
                .FirstOrDefaultAsync();

            return image == null ? null : image.Images[0];
        }

        public async Task Remove(string id)
        {
            await _images.DeleteOneAsync(i => i.Id == id);
        }

    }
}
