﻿using Domin.Abstraction;
using Domin.Entity;
using InfraStructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Impelementation
{
    internal class WriteUnitOfWork : IWriteUnitOfWork
    {
        IDbContextTransaction _transaction;
        WriteSystemDbContext _Wcontext;
        ConcurrentDictionary<object,object> repo;

        public WriteUnitOfWork(WriteSystemDbContext wcontext)
        {
            _Wcontext = wcontext;
        }


        

        public async Task BeginTransiaction()
        {
            // Check if a transaction is already in progress
            if (_transaction != null)
            {
                throw new InvalidOperationException("A transaction is already in progress.");
            }
            // Start a new transaction
            // transaction is used to ensure that all operations within the transaction scope are atomic
            //this will ensure that either all operations succeed or none do, maintaining data integrity.
            _transaction = await _Wcontext.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("No transaction in progress to commit.");
            }
            try
            {
                await _transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await RollbackAsync();
                throw new InvalidOperationException("Failed to commit transaction.", ex);
            }
            finally
            {
                await DisposeTransactionAsync();
            }
        }

        public void Dispose()
        {
            //if (_transaction != null)
            //{
            //    _transaction.Dispose();
            //    _transaction = null;
            //}
            //_context?.Dispose();
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_transaction != null)
                {
                    _transaction.Dispose();
                    _transaction = null;
                }
                _Wcontext?.Dispose();
            }
        }     
        public IWriteGenericRepo<T> GetWriteGenericRepo<T>() where T : BaseEntity
        => (IWriteGenericRepo<T>)repo.GetOrAdd(typeof(T), _ => new WriteGenericRepo<T>(_Wcontext));        

        public async Task RollbackAsync()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("No transaction in progress to rollback.");
            }
            try
            {
                await _transaction.RollbackAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to rollback transaction.", ex);
            }
            finally
            {
                await DisposeTransactionAsync();
            }
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _Wcontext.SaveChangesAsync();
                if (_transaction != null)
                {
                    await CommitAsync();
                }
            }
            catch (DbUpdateException ex)
            {
                if (_transaction != null)
                {
                    await RollbackAsync();
                }
                // Extract entity details from the exception
                var errorDetails = ex.Entries.Select(e => $"Entity: {e.Entity.GetType().Name}, State: {e.State}");
                throw new InvalidOperationException($"Failed to save changes: {string.Join("; ", errorDetails)}", ex);
            }
        }
        private async Task DisposeTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        ~WriteUnitOfWork()
        {
            Dispose(false);
        }
    }
}
