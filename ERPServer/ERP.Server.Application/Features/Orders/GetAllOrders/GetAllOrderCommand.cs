﻿using ERPServer.Domain.Entities;
using GenericRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Server.Application.Features.Orders.GetAllOrders
{
    public sealed record GetAllOrderCommand
        (
        
        ):IRequest<Result<List<Order>>>;
}