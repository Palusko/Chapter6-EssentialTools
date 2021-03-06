﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chapter6_EssentialTools.Models
{
  public interface IDiscountHelper
  {
    decimal ApplyDiscount(decimal totalParam);
  }

  public class DefaultDicountHelper : IDiscountHelper
  {
    public decimal discountSize;

    public DefaultDicountHelper(decimal discountParam)
    {
      discountSize = discountParam;
    }

    public decimal ApplyDiscount(decimal totalParam)
    {
      return (totalParam - (discountSize / 100m * totalParam));
    }
  }
}