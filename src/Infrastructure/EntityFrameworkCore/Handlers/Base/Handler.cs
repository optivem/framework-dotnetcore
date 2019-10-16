﻿using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Common;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public abstract class Handler<TContext, TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IResponse
        where TContext : DbContext
    {
        // TODO: VC: REmove mapper

        public Handler(TContext context)
        {
            Context = context;
        }

        public TContext Context { get; }

        public abstract Task<TResponse> HandleAsync(TRequest request);

        // TODO: VC: Check how to use

        /*
         *
    public class AddAggregatesRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId> : CommandHandler<TContext, TAggregateRoot, TIdentity, TRecord, TId>, IAddAggregatesRepository<TAggregateRoot, TIdentity>
        where TContext : DbContext
        where TAggregateRoot : class, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
        where TRecord : class, IRecord<TId>
        where TId : IEquatable<TId>
         *
         */

        /*
         *
        public CommandHandler(TContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public CommandHandler(TContext context, IMapper mapper) : base(context, mapper)
        {
            MutableSet = context.Set<TRecord>();
        }

        protected DbSet<TRecord> MutableSet { get; }

        public abstract Task<TRequest> HandleAsync(TRequest request);
         *
         *
         *
         *
         *
        public QueryableRepository(TContext context, IMapper mapper, IEnumerable<Expression<Func<TRecord, object>>> includes) : base(context, mapper)
        {
            ReadonlySet = Context.Set<TRecord>().AsNoTracking();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    ReadonlySet = ReadonlySet.Include(include);
                }
            };
        }

        protected IQueryable<TRecord> ReadonlySet { get; }
         *
         *
         */
    }
}