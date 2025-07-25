﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ICommentService:IGenericService<Comment>
    {
        List<Comment> TGetDestinationByID(int id);
        List<Comment> TGetListCommentWithDestination();
    }
}
