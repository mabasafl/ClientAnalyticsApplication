﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Interfaces
{
    public interface IMapper<TModel,TDto>
    {
        TDto Map(TModel model); 
        TModel Map(TDto dto);
    }
}