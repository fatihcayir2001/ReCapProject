﻿using Core.Utilities.Results;
using Entites.Concerete;
using System;
using System.Collections.Generic;
using System.Text;
using Entites.DTOs;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IResult Add(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);
        IDataResult<List<CustomerDetailDto>> GetCustomerDetails();

    }
}
