﻿using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Casino.Services.Util.Collections
{
    public sealed class PagedRecords<T> : IPagedRecords, IDisposable
    {
        private int _recordsPerPage = 15;
        private int _page = 0;
        private int _totalPages = 0;
        private int _totalRecords = 0;

        private IQueryable<T> _entityQueryBuilder;

        public int RecordsPerPage
        {
            get => _recordsPerPage;
            set => _recordsPerPage = CheckMinimumValue(value, 1);
        }

        public int TotalRecords => _totalRecords;

        public int Page
        {
            get => _page;
            set => _page = CheckMinimumValue(value, 1);
        }

        public int TotalPages => _totalPages;

        public IEnumerable Result { get; set; }


        private int CheckMinimumValue(int value, int min)
        {
            if (value < min)
                throw new InvalidOperationException("page minimium value is 1");

            return value;
        }

        public PagedRecords(IQueryable<T> entityQueryBuilder, int page, int recodsPerPage)
        {
            Initialize(entityQueryBuilder, page, recodsPerPage);
        }

        public PagedRecords(IEnumerable<T> entityCollection, int page, int recodsPerPage)
        {
            IQueryable<T> queryable = entityCollection.AsQueryable<T>();
            Initialize(queryable, page, recodsPerPage);
        }

        private void Initialize(IQueryable<T> entityQueryBuilder, int page, int recodsPerPage)
        {
            _entityQueryBuilder = entityQueryBuilder;
            Page = page;
            RecordsPerPage = recodsPerPage;
        }

        public async Task Build()
        {
            _totalRecords = await _entityQueryBuilder.CountAsync();

            Result = await _entityQueryBuilder
                .Skip(_recordsPerPage * (Page - 1))
                .Take(_recordsPerPage)
                .ToListAsync();

            _totalPages = ((int)Math.Ceiling((double)_totalRecords / _recordsPerPage));
        }

        public void Dispose()
        {
            Result = null;
            _entityQueryBuilder = null;
        }
    }
}