﻿using System;

namespace SlothEnterprise.ProductApplication.Applications
{

    /// <summary>
    /// Solid principle violated
    /// </summary>

    public class SellerCompanyData : ISellerCompanyData
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public string DirectorName { get; set; }
        public DateTime Founded { get; set; }
    }
}