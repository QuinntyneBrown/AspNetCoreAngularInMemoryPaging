using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreAngularInMemoryPaging.Api.Core;
using AspNetCoreAngularInMemoryPaging.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreAngularInMemoryPaging.Api.Features
{
    public class GetPlayerById
    {
        public class Request: IRequest<Response>
        {
            public Guid PlayerId { get; set; }
        }

        public class Response: ResponseBase
        {
            public PlayerDto Player { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IAspNetCoreAngularInMemoryPagingDbContext _context;
        
            public Handler(IAspNetCoreAngularInMemoryPagingDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    Player = (await _context.Players.SingleOrDefaultAsync(x => x.PlayerId == request.PlayerId)).ToDto()
                };
            }
            
        }
    }
}
