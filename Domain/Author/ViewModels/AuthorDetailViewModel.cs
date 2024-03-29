﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrySimpleApi.Domain.Product.ViewModels;

namespace TrySimpleApi.Domain.Author.ViewModels
{
    public class AuthorDetailViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Position { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<ProductDetailViewModel> Products { get; set; }

    }
}
