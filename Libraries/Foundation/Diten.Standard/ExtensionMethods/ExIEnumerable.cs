using System;
using System.Collections.Generic;
using System.Text;

namespace Diten
{ 
  public static class ExIEnumerable
  {
    public static Int32 ToInt32(this IEnumerable<System.Byte> value) => ((System.Byte[]) value).ToInt32();
  }
}
