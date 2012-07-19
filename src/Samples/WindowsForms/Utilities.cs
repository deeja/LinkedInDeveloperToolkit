//-----------------------------------------------------------------------
// <copyright file="Utilities.cs">
//     Copyright (c) Andrew Arnott. All rights reserved.
// </copyright>
// <license>
//     Microsoft Public License (Ms-PL http://opensource.org/licenses/ms-pl.html).
//     Contributors may add their own copyright notice above.
// </license>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;
using System.Runtime.InteropServices;

namespace LinkedIn.Samples.WindowsForms
{
  public static class Utilities
  {
    /// <summary>
    /// Converts a SecureString to an ordinary String.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The ordinary String.</returns>
    /// <remarks>
    /// It is important to note that converting a SecureString to an ordinary
    /// string eliminates any added security that using a SecureString provides.
    /// </remarks>
    internal static string ToUnsecureString(this SecureString value)
    {
      if (value == null)
      {
        return null;
      }

      IntPtr bstr = Marshal.SecureStringToBSTR(value);

      try
      {
        return Marshal.PtrToStringBSTR(bstr);
      }
      finally
      {
        Marshal.ZeroFreeBSTR(bstr);
      }
    }

    /// <summary>
    /// Creates a SecureString instance from an ordinary string.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The SecureString.</returns>
    /// <remarks>
    /// It is important to note that although a SecureString instance is created, the entire
    /// process is insecure by nature since we built it out of an insecure string which remains
    /// in memory indefinitely.
    /// </remarks>
    internal static SecureString ToSecureString(this string value)
    {
      if (value == null)
      {
        return null;
      }

      SecureString secureString = new SecureString();
      Array.ForEach(value.ToCharArray(), s => secureString.AppendChar(s));
      return secureString;
    }
  }
}
