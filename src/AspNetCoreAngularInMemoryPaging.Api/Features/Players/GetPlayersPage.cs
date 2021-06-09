using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using AspNetCoreAngularInMemoryPaging.Api.Extensions;
using AspNetCoreAngularInMemoryPaging.Api.Core;
using AspNetCoreAngularInMemoryPaging.Api.Interfaces;
using AspNetCoreAngularInMemoryPaging.Api.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreAngularInMemoryPaging.Api.Features
{
    public class GetPlayersPage
    {
        public class Request: IRequest<Response>
        {
            public int PageSize { get; set; }
            public int Index { get; set; }
        }

        public class Response: ResponseBase
        {
            public int Length { get; set; }
            public List<PlayerDto> Entities { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IAspNetCoreAngularInMemoryPagingDbContext _context;
        
            public Handler(IAspNetCoreAngularInMemoryPagingDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var query = from player in _context.Players
                    select player;
                
                var length = await _context.Players.CountAsync();
                
                var players = await query.Page(request.Index, request.PageSize)
                    .Select(x => x.ToDto()).ToListAsync();
                
                return new()
                {
                    Length = length,
                    Entities = players
                };
            }
            
        }
    }
}
