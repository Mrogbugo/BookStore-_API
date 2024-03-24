using BookStoreAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreAPI.Repository
{
    public interface IBookRepository
    {
        Task<List<BookModel>> GetAllBooksAsync();
        Task<BookModel> GetBooKById(int id);
        Task<int> AddBooKs(BookModel model);
        Task UpdateBooKDetailsAsync(int BookId, BookModel model); 
        Task UpdateBooKPatchAsync(int BookId, JsonPatchDocument model);
        Task<int> DeleteBookAsync(int BookId);
        Task DeleteBookById(int Id);
    }
}
