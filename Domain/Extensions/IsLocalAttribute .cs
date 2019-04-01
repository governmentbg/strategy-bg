using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Domain.Extensions
{
  public static class IsLocalExtension
  {
    private const string NullIpAddress = "::1";

    public static bool IsLocal(this HttpRequest req)
    {
      var connection = req.HttpContext.Connection;
      if (connection.RemoteIpAddress.IsSet())
      {
        //We have a remote address set up
        return connection.LocalIpAddress.IsSet()
            //Is local is same as remote, then we are local
            ? connection.RemoteIpAddress.Equals(connection.LocalIpAddress)
            //else we are remote if the remote IP address is not a loopback address
            : IPAddress.IsLoopback(connection.RemoteIpAddress);
      }

      return true;
    }

    private static bool IsSet(this IPAddress address)
    {
      return address != null && address.ToString() != NullIpAddress;
    }
  }
}
