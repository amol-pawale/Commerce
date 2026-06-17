using System;
using System.Collections.Generic;
using Commerce.Domain.Common;

namespace Commerce.Domain.Entities;

public class Category : BaseEntity
{
    public string Name {get; private set;} = string.Empty;

    public string? Description {get; private set};

    public readonly List<Category> _subCategories = new();
    
}
