﻿using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> GetById(int Id);
        IResult Insert(Color color);
        IResult Update(Color color);
        IResult Delete(Color color);
    }
}
