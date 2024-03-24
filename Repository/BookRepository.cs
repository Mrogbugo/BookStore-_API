using AutoMapper;
using BookStoreAPI.Entities;
using BookStoreAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public BookRepository(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        } 


        public async Task<List<BookModel>> GetAllBooksAsync()
        {

            var UsingAutoMapper = await _context.Books.ToListAsync();
            return _mapper.Map<List<BookModel>>(UsingAutoMapper);   

            // var records = await _context.Books.Select(x=> new BookModel()
            // {
            //     Id = x.Id,
            //     Title = x.Title,
            //     Description = x.Description,
            // }).ToListAsync();

            //return records;
        }


        public async Task<BookModel> GetBooKById(int id)
        {  

            var record = await _context.Books.FindAsync(id);
            return _mapper.Map<BookModel>(record);  // using Automapper

            //var record = await _context.Books.Where(x=>x.Id == id).Select(x=> new BookModel()
            //{   Id = x.Id, 
            //    Title = x.Title,
            //    Description = x.Description,
            //}).SingleOrDefaultAsync();
            //return record;  
        }


        public async Task<int> AddBooKs(BookModel model)
        {
            var record = new Book()
            {
             
                Title = model.Title,
                Description = model.Description,
            };
            _context.Books.Add(record);
            await _context.SaveChangesAsync();
            return record.Id;
        }


        public async Task UpdateBooKDetailsAsync(int BookId, BookModel model)
        {
            //var book = await _context.Books.FindAsync(BookId); 
            //if(book != null)
            //{
            //  book.Title = model.Title;
            //  book.Description = model.Description;
            //    await _context.SaveChangesAsync();
            //}  

            var update = new Book()
            {
                Id = BookId,
                Title = model.Title,
                Description = model.Description,
            }; 
            _context.Books.Update(update);
            await _context.SaveChangesAsync();
          
        }

        public async Task UpdateBooKPatchAsync(int  BookId, JsonPatchDocument model)
        {
            var UpdateSingleProp = await _context.Books.FindAsync(BookId); 
            if(UpdateSingleProp != null)
            {
                model.ApplyTo(UpdateSingleProp); 
                await _context.SaveChangesAsync();
            }

        }


        public async Task<int> DeleteBookAsync(int BookId)
        {

            var delete = await _context.Books.Where(x => x.Id == BookId).FirstOrDefaultAsync(); // these assume you don't have the primary key 
            _context.Books.Remove(delete);
            await _context.SaveChangesAsync();
            return delete.Id;

        }   


        public async Task DeleteBookById(int Id)
        {
            var book = new Book()
            {
                Id = Id, 
               
            };
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

    } 
}
