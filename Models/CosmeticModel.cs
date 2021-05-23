﻿using System;
using System.Collections.Generic;

namespace Models
{
    [Serializable]
    public class CosmeticModel : BaseModel
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int DeliveryTime { get; set; }
        public int ShelfLife { get; set; }
    }
}