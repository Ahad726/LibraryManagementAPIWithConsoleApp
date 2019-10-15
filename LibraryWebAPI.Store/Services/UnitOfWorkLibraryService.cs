using LibraryWebAPI.Store.IRepositories;
using LibraryWebAPI.Store.IServices;
using LibraryWebAPI.Store.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWebAPI.Store.Services
{
    public class UnitOfWorkLibraryService : IUnitOfWorkLibraryService
    {
        private LibraryContext _context;

        public IBookIssueRepository BookIssueRepositor  { get; private set; }
        public IReturnBookRepository ReturnBookRepository   { get; private set; }
        public IBookRepository BookRepository  { get; private set; }
        public IStudentRepository StudentRepository   { get; private set; }


        public UnitOfWorkLibraryService(string connectionString, string migrationAssemblyName)
        {
            _context = new LibraryContext(connectionString, migrationAssemblyName);

            BookIssueRepositor = new BookIssueRepository(_context);
            ReturnBookRepository = new ReturnBookRepository(_context);
            BookRepository = new BookRepository(_context);
            StudentRepository = new StudentRepository(_context);
           
        }

        public void save()
        {
            _context.SaveChanges();
        }


    }
}
